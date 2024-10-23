
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.TranslationMemory;

using TranslationMemoryResource = Crowdin.Api.TranslationMemory.TranslationMemory;

namespace Crowdin.Api.UnitTesting.Tests.TranslationMemory
{
    public class TranslationMemoryApiTests
    {
        private const string BaseUrl = "/tms";

        private static readonly JsonSerializerSettings DefaultSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListTms()
        {
            const int userId = 2, groupId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            queryParams.Add(nameof(userId), userId.ToString());
            queryParams.Add(nameof(groupId), groupId.ToString());

            mockClient
                .Setup(client => client.SendGetRequest(BaseUrl, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.TranslationMemory.CommonResponse_Multi)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            ResponseList<TranslationMemoryResource>? response = await executor.ListTms(userId, groupId);

            Assert.NotNull(response);
            Assert.Single(response.Data);
            Assert_TranslationMemory(response.Data[0]);
        }

        [Fact]
        public async Task AddTm()
        {
            var request = new AddTmRequest
            {
                Name = "Knowledge Base's TM",
                LanguageId = "fr",
                GroupId = 2
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.TranslationMemory.AddTm_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest(BaseUrl, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Created,
                    JsonObject = JObject.Parse(Resources.TranslationMemory.CommonResponse_Single)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            TranslationMemoryResource? response = await executor.AddTm(request);

            Assert_TranslationMemory(response);
        }

        [Fact]
        public async Task GetTm()
        {
            const int tmId = 4;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"{BaseUrl}/{tmId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.TranslationMemory.CommonResponse_Single)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            TranslationMemoryResource? response = await executor.GetTm(tmId);

            Assert_TranslationMemory(response);
        }

        [Fact]
        public async Task DeleteTm()
        {
            const int tmId = 4;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"{BaseUrl}/{tmId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            await executor.DeleteTm(tmId);
        }

        [Fact]
        public async Task EditTm()
        {
            const int tmId = 1;

            var patches = new[]
            {
                new TmPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = TmPatchPath.Name,
                    Value = "Knowledge Base's TM"
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(patches, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.TranslationMemory.EditTm_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"{BaseUrl}/{tmId}";

            mockClient
                .Setup(client => client.SendPatchRequest(url, patches, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.TranslationMemory.CommonResponse_Single)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            TranslationMemoryResource? response = await executor.EditTm(tmId, patches);

            Assert_TranslationMemory(response);
        }

        [Fact]
        public async Task ClearTm()
        {
            const int tmId = 4;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"{BaseUrl}/{tmId}/segments";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            await executor.ClearTm(tmId);
        }

        [Fact]
        public async Task ExportTm()
        {
            const int tmId = 1;

            var request = new ExportTmRequest
            {
                SourceLanguageId = "en",
                TargetLanguageId = "de",
                Format = TmFileFormat.Csv
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.TranslationMemory.ExportTm_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/tms/{tmId}/exports";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Accepted,
                    JsonObject = JObject.Parse(Resources.TranslationMemory.ExportTm_Response)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            TmExportStatus? response = await executor.ExportTm(tmId, request);

            Assert_TmExportStatus(response);
        }

        [Fact]
        public async Task CheckTmExportStatus()
        {
            const int tmId = 1;
            const string exportId = "1";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"{BaseUrl}/{tmId}/exports/{exportId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.TranslationMemory.CheckTmExportStatus_Response)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            TmExportStatus? response = await executor.CheckTmExportStatus(tmId, exportId);

            Assert_TmExportStatus(response);
        }

        [Fact]
        public async Task DownloadTm()
        {
            const int tmId = 1;
            const string exportId = "1";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"{BaseUrl}/{tmId}/exports/{exportId}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.TranslationMemory.DownloadTm_Response)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            DownloadLink? response = await executor.DownloadTm(tmId, exportId);

            Assert.NotNull(response);
            Assert.NotEmpty(response.Url);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T10:31:21+00:00"), response.ExpireIn);
        }

        [Fact]
        public async Task ImportTm()
        {
            const int tmId = 10;

            var request = new ImportTmRequest
            {
                StorageId = 28,
                FirstLineContainsHeader = false,
                Scheme = new Dictionary<string, int>
                {
                    ["en"] = 0,
                    ["de"] = 1,
                    ["pl"] = 2,
                    ["uk"] = 4
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.TranslationMemory.ImportTm_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/tms/{tmId}/imports";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Accepted,
                    JsonObject = JObject.Parse(Resources.TranslationMemory.ImportTm_Response)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            TmImportStatus? response = await executor.ImportTm(tmId, request);

            Assert_TmImportStatus(response);
        }

        [Fact]
        public async Task CheckTmImportStatus()
        {
            const int tmId = 10;
            const string importId = "1";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"{BaseUrl}/{tmId}/imports/{importId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.TranslationMemory.CheckTmImportStatus_Response)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            TmImportStatus? response = await executor.CheckTmImportStatus(tmId, importId);

            Assert_TmImportStatus(response);
        }

        [Fact]
        public async Task ConcordanceSearch()
        {
            const int projectId = 1;

            var request = new ConcordanceSearchRequest
            {
                SourceLanguageId = "en",
                TargetLanguageId = "de",
                AutoSubstitution = true,
                MinRelevant = 60,
                Expression = "Welcome!"
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, DefaultSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.TranslationMemory.ConcordanceSearch_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/tms/concordance";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.TranslationMemory.ConcordanceSearch_Response)
                });

            var executor = new TranslationMemoryApiExecutor(mockClient.Object);
            ResponseList<TmConcordanceResultResource>? response = await executor.ConcordanceSearch(projectId, request);

            Assert.NotNull(response);

            TmConcordanceResultResource? resource = response.Data?.Single();
            Assert.NotNull(resource);

            TranslationMemoryResource tm = resource!.Tm;
            Assert.NotNull(tm);
            Assert.Equal(4, tm.Id);
            Assert.Equal("Knowledge Base's TM", tm.Name);
            Assert.Equal("el", tm.LanguageIds?.Single());
            Assert.Equal(21, tm.SegmentsCount);
            Assert.Equal(2, tm.ProjectIds?.Single());
            Assert.Equal(DateTimeOffset.Parse("2019-09-16T13:42:04+00:00"), tm.CreatedAt);

            Assert.Equal(34, resource.RecordId);
            Assert.Equal("Welcome!", resource.Source);
            Assert.Equal("Ласкаво просимо!", resource.Target);
            Assert.Equal(100, resource.Relevant);
            Assert.Equal("62→100", resource.Substituted);
            Assert.Equal(DateTimeOffset.Parse("2022-09-28T12:29:34+00:00"), resource.UpdatedAt);
        }

        private static void Assert_TmExportStatus(TmExportStatus? model)
        {
            Assert.NotNull(model);
            Assert.Equal(OperationStatus.Finished, model!.Status);

            Assert.NotNull(model.Attributes);
            Assert.Equal("en", model.Attributes.SourceLanguageId);
            Assert.Equal("de", model.Attributes.TargetLanguageId);
            Assert.Equal(TmFileFormat.Csv, model.Attributes.Format);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00");
            Assert.Equal(date, model.CreatedAt);
            Assert.Equal(date, model.UpdatedAt);
            Assert.Equal(date, model.StartedAt);
            Assert.Equal(date, model.FinishedAt);
        }

        private static void Assert_TmImportStatus(TmImportStatus? model)
        {
            Assert.NotNull(model);
            Assert.Equal(OperationStatus.Created, model!.Status);

            Assert.NotNull(model.Attributes);
            Assert.Equal(10, model.Attributes.TmId);
            Assert.Equal(28, model.Attributes.StorageId);

            Assert.NotNull(model.Attributes.Scheme);
            Assert.Contains("en", model.Attributes.Scheme);
            Assert.Contains("de", model.Attributes.Scheme);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:51:08+00:00");
            Assert.Equal(date, model.CreatedAt);
            Assert.Equal(date, model.UpdatedAt);
            Assert.Equal(date, model.StartedAt);
            Assert.Equal(date, model.FinishedAt);
        }

        private static void Assert_TranslationMemory(TranslationMemoryResource? model)
        {
            Assert.NotNull(model);

            Assert.Equal(4, model!.Id);
            Assert.Equal(2, model.GroupId);
            Assert.Equal(2, model.UserId);
            Assert.Equal("Knowledge Base's TM", model.Name);

            Assert.NotNull(model.LanguageIds);
            Assert.Single(model.LanguageIds);
            Assert.Equal("el", model.LanguageIds[0]);

            Assert.Equal(21, model.SegmentsCount);

            Assert.NotNull(model.DefaultProjectIds);
            Assert.Single(model.DefaultProjectIds);
            Assert.Equal(2, model.DefaultProjectIds[0]);

            Assert.NotNull(model.ProjectIds);
            Assert.Single(model.ProjectIds);
            Assert.Equal(2, model.ProjectIds[0]);

            Assert.Equal(DateTimeOffset.Parse("2019-09-16T13:42:04+00:00"), model.CreatedAt);
        }
    }
}