
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Bundles;
using Crowdin.Api.Core;
using Crowdin.Api.Tests.Core;

namespace Crowdin.Api.Tests.Bundles
{
    public class BundlesApiTests
    {
        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();
        
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
            ResponseList<Bundle> response = await executor.ListBundles(projectId);
            
            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert.Equal("/master/", response.Data[0].SourcePatterns[0]);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T11:11:05+00:00"), response.Data[0].CreatedAt);
        }
        
        [Fact]
        public async Task AddBundle()
        {
            const int projectId = 1;
            
            var request = new AddBundleRequest
            {
                ApplicationId = "resx-string-exporter",
                SourcePatterns = new[]
                {
                    "/master/"
                },
                IgnorePatterns = new[]
                {
                    "/master/environments/"
                },
                ExportPattern = "strings-%two_letter_code%.resx",
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
                    JsonObject = JObject.Parse(Core.Resources.Bundles.AddBundle_Response)
                });
            
            var executor = new BundlesApiExecutor(mockClient.Object);
            Bundle response = await executor.AddBundle(projectId, request);
            
            Assert.NotNull(response);
            Assert.Equal(request.SourcePatterns.First(), response.SourcePatterns[0]);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T11:11:05+00:00"), response.CreatedAt);
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
                    Path = BundlePatchPath.ApplicationId,
                    Value = "resx-string-exporter"
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
                    JsonObject = JObject.Parse(Core.Resources.Bundles.EditBundle_Response)
                });
            
            var executor = new BundlesApiExecutor(mockClient.Object);
            Bundle response = await executor.EditBundle(projectId, bundleId, patches);
            
            Assert.NotNull(response);
            Assert.Equal("/master/environments/", response.IgnorePatterns[0]);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T11:11:05+00:00"), response.CreatedAt);
        }
    }
}