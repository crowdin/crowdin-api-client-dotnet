
using Crowdin.Api.Bundles;
using Crowdin.Api.Core;
using Crowdin.Api.SourceFiles;
using Crowdin.Api.Tests.Core;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Crowdin.Api.Tests.Bundles
{
    public class BundlesApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListBundleBranches()
        {
            const int projectId = 1;
            const int bundleId = 1;


            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/bundles/{bundleId}/branches";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Bundles.ListBundleBranches_Response)
                });

            var executor = new BundlesApiExecutor(mockClient.Object);
            ResponseList<Branch>? response = await executor.ListBundleBranches(projectId, bundleId);

            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.IsType<Branch>(response.Data[0]);
            Assert.Equal(projectId, response.Data[0].ProjectId);
            Assert.Equal(bundleId, response.Data[0].Id);
        }

        [Fact]
        public async Task ListBundles()
        {
            const int projectId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/bundles";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Bundles.ListBundles_Response)
                });

            var executor = new BundlesApiExecutor(mockClient.Object);
            ResponseList<Bundle>? response = await executor.ListBundles(projectId);

            Assert.NotNull(response);
            Assert.Single(response.Data);

            Assert_Bundle(response.Data[0]);
        }

        [Fact]
        public async Task AddBundle()
        {
            const int projectId = 1;

            var request = new AddBundleRequest
            {
                Name = "Resx bundle",
                Format = "crowdin-resx",
                SourcePatterns = new[]
                {
                    "/master/"
                },
                IgnorePatterns = new[]
                {
                    "/master/environments/"
                },
                ExportPattern = "strings-%two_letter_code%.resx",
                IsMultilingual = false,
                IncludeProjectSourceLanguage = false,
                LabelIds = new[]
                {
                    0
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Bundles.AddBundle_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/bundles";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Bundles.CommonResponses_Bundle)
                });

            var executor = new BundlesApiExecutor(mockClient.Object);
            Bundle? response = await executor.AddBundle(projectId, request);

            Assert_Bundle(response);
        }

        [Fact]
        public async Task GetBundle()
        {
            const int projectId = 1, bundleId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/bundles/{bundleId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Bundles.CommonResponses_Bundle)
                });

            var executor = new BundlesApiExecutor(mockClient.Object);
            Bundle? response = await executor.GetBundle(projectId, bundleId);

            Assert_Bundle(response);
        }

        [Fact]
        public async Task DeleteBundle()
        {
            const int projectId = 1, bundleId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/bundles/{bundleId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new BundlesApiExecutor(mockClient.Object);
            await executor.DeleteBundle(projectId, bundleId);
        }

        [Fact]
        public async Task EditBundle()
        {
            const int projectId = 1;
            const int bundleId = 2;

            var patches = new[]
            {
                new BundlePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = BundlePatchPath.Name,
                    Value = "Resx bundle"
                },
                new BundlePatch
                {
                    Operation = PatchOperation.Replace,
                    Path = BundlePatchPath.IncludeProjectSourceLanguage,
                    Value = false
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Core.Resources.Bundles.EditBundle_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/bundles/{bundleId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Bundles.CommonResponses_Bundle)
                });

            var executor = new BundlesApiExecutor(mockClient.Object);
            Bundle? response = await executor.EditBundle(projectId, bundleId, patches);

            Assert_Bundle(response);
        }

        [Fact]
        public async Task DownloadBundle()
        {
            const int projectId = 1, bundleId = 2;
            const string exportId = "50fb3506-4127-4ba8-8296-f97dc7e3e0c3";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/bundles/{bundleId}/exports/{exportId}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Bundles.DownloadBundle_Response)
                });

            var executor = new BundlesApiExecutor(mockClient.Object);
            DownloadLink? response = await executor.DownloadBundle(projectId, bundleId, exportId);

            Assert.NotNull(response);
            Assert.NotEmpty(response.Url);
            Assert.StartsWith("https", response.Url);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T10:31:21+00:00"), response.ExpireIn);
        }

        [Fact]
        public async Task ExportBundle()
        {
            const int projectId = 1, bundleId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/bundles/{bundleId}/exports";

            mockClient
                .Setup(client => client.SendPostRequest(url, null, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Accepted,
                    JsonObject = JObject.Parse(Core.Resources.Bundles.CommonResponses_BundleExport)
                });

            var executor = new BundlesApiExecutor(mockClient.Object);
            BundleExport? response = await executor.ExportBundle(projectId, bundleId);

            Assert_BundleExport(response);
        }

        [Fact]
        public async Task CheckBundleExportStatus()
        {
            const int projectId = 1, bundleId = 2;
            const string exportId = "50fb3506-4127-4ba8-8296-f97dc7e3e0c3";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/bundles/{bundleId}/exports/{exportId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Bundles.CommonResponses_BundleExport)
                });

            var executor = new BundlesApiExecutor(mockClient.Object);
            BundleExport? response = await executor.CheckBundleExportStatus(projectId, bundleId, exportId);

            Assert_BundleExport(response);
        }

        private static void Assert_Bundle(Bundle? model)
        {
            Assert.NotNull(model);

            Assert.Equal(1, model!.Id);
            Assert.Equal("Resx bundle", model.Name);
            Assert.Equal("crowdin-resx", model.Format);

            Assert.NotNull(model.SourcePatterns);
            Assert.Single(model.SourcePatterns);
            Assert.Equal("/master/", model.SourcePatterns[0]);

            Assert.NotNull(model.IgnorePatterns);
            Assert.Single(model.IgnorePatterns);
            Assert.Equal("/master/environments/", model.IgnorePatterns[0]);

            Assert.Equal("strings-%two_letters_code%.resx", model.ExportPattern);
            Assert.False(model.IsMultilingual);

            Assert.False(model.IncludeProjectSourceLanguage);

            Assert.NotNull(model.LabelIds);
            Assert.Single(model.LabelIds);
            Assert.Equal(0, model.LabelIds[0]);

            Assert.NotNull(model.ExcludeLabelIds);
            Assert.Single(model.ExcludeLabelIds);
            Assert.Equal(1, model.ExcludeLabelIds[0]);

            Assert.Equal(DateTimeOffset.Parse("2019-09-20T11:11:05+00:00"), model.CreatedAt);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T12:22:20+00:00"), model.UpdatedAt);
        }

        private static void Assert_BundleExport(BundleExport? model)
        {
            Assert.NotNull(model);

            Assert.True(Guid.TryParse(model!.Identifier, out _));
            Assert.Equal(BuildStatus.Finished, model.Status);
            Assert.Equal(100, model.Progress);

            Assert.NotNull(model.Attributes);
            Assert.Equal(2, model.Attributes.BundleId);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00");
            Assert.Equal(date, model.CreatedAt);
            Assert.Equal(date, model.UpdatedAt);
            Assert.Equal(date, model.StartedAt);
            Assert.Equal(date, model.FinishedAt);
        }
    }
}