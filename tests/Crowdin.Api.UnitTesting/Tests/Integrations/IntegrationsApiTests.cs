using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using Crowdin.Api.Integrations;
using Crowdin.Api.UnitTesting.Resources;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using IntegrationFixtures = Crowdin.Api.UnitTesting.Resources.Integrations;

namespace Crowdin.Api.UnitTesting.Tests.Integrations
{
    public class IntegrationsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListJobs()
        {
            IDictionary<string, string> queryParams = new IntegrationJobsListParams { ProjectId = 7 }.ToQueryParams();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/applications/app/api/all-jobs", queryParams))
                .ReturnsAsync(ApiResult("ListJobs"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            IList<IntegrationJob> response = await executor.ListJobs("app", 7);

            Assert.Single(response);
            Assert.Equal("job-list", response[0].JobId);
            Assert.Equal("finished", response[0].AdditionalData["status"].Value<string>());
            Assert.Equal(7, response[0].AdditionalData["projectId"].Value<long>());
        }

        [Fact]
        public async Task GetJobInfo()
        {
            IDictionary<string, string> queryParams = new IntegrationJobsListParams { ProjectId = 7, JobId = "job" }.ToQueryParams();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/applications/app/api/job-info", queryParams))
                .ReturnsAsync(ApiResult("GetJobInfo"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            IList<IntegrationJob> response = await executor.GetJobInfo("app", 7, "job");

            Assert.Single(response);
            Assert.Equal("job-info", response[0].JobId);
            Assert.Equal("inProgress", response[0].AdditionalData["status"].Value<string>());
            Assert.Equal(40, response[0].AdditionalData["progress"].Value<int>());
        }

        [Fact]
        public async Task GetJobs()
        {
            IDictionary<string, string> queryParams = new IntegrationJobsListParams { ProjectId = 7, JobId = "job" }.ToQueryParams();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/applications/app/api/jobs", queryParams))
                .ReturnsAsync(ApiResult("GetJobs"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            IList<IntegrationJob> response = await executor.GetJobs("app", 7, "job");

            Assert.Single(response);
            Assert.Equal("job-get", response[0].JobId);
            Assert.Equal("finished", response[0].AdditionalData["status"].Value<string>());
        }

        [Fact]
        public async Task CancelJob()
        {
            IDictionary<string, string> queryParams = new IntegrationJobsListParams { ProjectId = 7, JobId = "job" }.ToQueryParams();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendDeleteRequest("/applications/app/api/jobs", queryParams))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            await executor.CancelJob("app", 7, "job");

            mockClient.Verify(client => client.SendDeleteRequest("/applications/app/api/jobs", queryParams), Times.Once);
        }

        [Fact]
        public async Task ListIntegrationCrowdinFiles()
        {
            IDictionary<string, string> queryParams = new IntegrationFilesListParams { ProjectId = 7 }.ToQueryParams();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/applications/app/api/crowdin-files", queryParams))
                .ReturnsAsync(ApiResult("ListIntegrationCrowdinFiles"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            IList<JObject> response = await executor.ListIntegrationCrowdinFiles("app", 7);

            Assert.Single(response);
            Assert.Equal(11, response[0]["id"]!.Value<long>());
            Assert.Equal("messages.json", response[0]["name"]!.Value<string>());
            Assert.Equal("/messages.json", response[0]["path"]!.Value<string>());
        }

        [Fact]
        public async Task UpdateIntegrationCrowdinFiles()
        {
            var request = new UpdateCrowdinFilesRequest
            {
                ProjectId = 7,
                Files = JArray.Parse("[{\"id\":11}]"),
                UploadTranslations = true
            };
            AssertRequest(request, "UpdateIntegrationCrowdinFiles");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPostRequest("/applications/app/api/crowdin-update", request, null))
                .ReturnsAsync(ApiResult("UpdateIntegrationCrowdinFiles"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            IntegrationJob response = await executor.UpdateIntegrationCrowdinFiles("app", request);

            Assert.Equal("crowdin-update", response.JobId);
            Assert.Equal("created", response.AdditionalData["status"].Value<string>());
            Assert.Equal(7, response.AdditionalData["projectId"].Value<long>());
        }

        [Fact]
        public async Task GetIntegrationFileProgress()
        {
            IDictionary<string, string> queryParams = new IntegrationFilesListParams { ProjectId = 7, FileId = 3 }.ToQueryParams();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/applications/app/api/file-progress", queryParams))
                .ReturnsAsync(ApiResult("GetIntegrationFileProgress"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            IntegrationFileProgress response = await executor.GetIntegrationFileProgress("app", 7, 3);

            Assert.Equal("uk", response.LanguageId);
            Assert.Equal("etag-1", response.ETag);
            Assert.Equal(100, response.Words.Total);
            Assert.Equal(75, response.Words.Translated);
            Assert.Equal(10, response.Phrases.Approved);
            Assert.Equal(75, response.TranslationProgress);
            Assert.Equal(50, response.ApprovalProgress);
        }

        [Fact]
        public async Task ListIntegrationFiles()
        {
            IDictionary<string, string> queryParams = new IntegrationFilesListParams { ProjectId = 7 }.ToQueryParams();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/applications/app/api/integration-files", queryParams))
                .ReturnsAsync(ApiResult("ListIntegrationFiles"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            IList<JObject> response = await executor.ListIntegrationFiles("app", 7);

            Assert.Single(response);
            Assert.Equal(12, response[0]["id"]!.Value<long>());
            Assert.Equal("integration.json", response[0]["name"]!.Value<string>());
        }

        [Fact]
        public async Task UpdateIntegrationFiles()
        {
            var request = new UpdateIntegrationFilesRequest
            {
                ProjectId = 7,
                Files = JObject.Parse("{\"11\":[\"uk\",\"fr\"]}")
            };
            AssertRequest(request, "UpdateIntegrationFiles");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPostRequest("/applications/app/api/integration-update", request, null))
                .ReturnsAsync(ApiResult("UpdateIntegrationFiles"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            IntegrationJob response = await executor.UpdateIntegrationFiles("app", request);

            Assert.Equal("integration-update", response.JobId);
            Assert.Equal("created", response.AdditionalData["status"].Value<string>());
        }

        [Fact]
        public async Task IntegrationLogin()
        {
            var request = new IntegrationLoginRequest
            {
                ProjectId = 7,
                Credentials = JObject.Parse("{\"token\":\"secret\"}")
            };
            AssertRequest(request, "IntegrationLogin");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPostRequest("/applications/app/api/login", request, null))
                .ReturnsAsync(ApiResult("IntegrationLogin"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            JObject? response = await executor.IntegrationLogin("app", request);

            Assert.NotNull(response);
            Assert.Equal("session-token", response!["token"]!.Value<string>());
            Assert.Equal(9, response["userId"]!.Value<long>());
        }

        [Fact]
        public async Task ListIntegrationLoginFields()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/applications/app/api/login-fields", null))
                .ReturnsAsync(ApiResult("ListIntegrationLoginFields"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            IList<IntegrationLoginField> response = await executor.ListIntegrationLoginFields("app");

            Assert.Single(response);
            Assert.Equal("token", response[0].Key);
            Assert.Equal("Access token", response[0].Name);
        }

        [Fact]
        public async Task GetApplicationSettings()
        {
            IDictionary<string, string> queryParams = new IntegrationSettingsParams { ProjectId = 7 }.ToQueryParams();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/applications/app/api/settings", queryParams))
                .ReturnsAsync(ApiResult("GetApplicationSettings"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            JObject response = await executor.GetApplicationSettings("app", 7);

            Assert.True(response["enabled"]!.Value<bool>());
            Assert.Equal(2, response["branchId"]!.Value<long>());
        }

        [Fact]
        public async Task UpdateApplicationSettings()
        {
            var request = new UpdateApplicationSettingsRequest
            {
                ProjectId = 7,
                Config = JObject.Parse("{\"enabled\":true}")
            };
            AssertRequest(request, "UpdateApplicationSettings");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPostRequest("/applications/app/api/settings", request, null))
                .ReturnsAsync(ApiResult("GetApplicationSettings"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            await executor.UpdateApplicationSettings("app", request);

            mockClient.Verify(client => client.SendPostRequest("/applications/app/api/settings", request, null), Times.Once);
        }

        [Fact]
        public async Task GetSyncSettings()
        {
            IDictionary<string, string> queryParams = new IntegrationSettingsParams { ProjectId = 7, Provider = "crowdin" }.ToQueryParams();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/applications/app/api/sync-settings", queryParams))
                .ReturnsAsync(ApiResult("GetSyncSettings"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            JToken response = await executor.GetSyncSettings("app", 7, "crowdin");

            Assert.Equal("crowdin", response["provider"]!.Value<string>());
            Assert.Equal(new[] { "uk", "fr" }, response["files"]!["11"]!.ToObject<string[]>());
        }

        [Fact]
        public async Task UpdateSyncSettings()
        {
            var request = new UpdateApplicationSyncSettingsRequest
            {
                ProjectId = 7,
                Provider = "crowdin",
                Files = JObject.Parse("{\"11\":[\"uk\"]}")
            };
            AssertRequest(request, "UpdateSyncSettings");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPostRequest("/applications/app/api/sync-settings", request, null))
                .ReturnsAsync(ApiResult("GetSyncSettings"));

            var executor = new IntegrationsApiExecutor(mockClient.Object);
            await executor.UpdateSyncSettings("app", request);

            mockClient.Verify(client => client.SendPostRequest("/applications/app/api/sync-settings", request, null), Times.Once);
        }

        private static CrowdinApiResult ApiResult(string key)
        {
            return new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = (JObject)JObject.Parse(IntegrationFixtures.ApiResponses)[key]!
            };
        }

        private static void AssertRequest(object request, string key)
        {
            JToken expected = JObject.Parse(IntegrationFixtures.ApiRequests)[key]!;
            JToken actual = JToken.Parse(JsonConvert.SerializeObject(request, JsonSettings));
            Assert.True(JToken.DeepEquals(expected, actual), $"Request {key} did not match its fixture.");
        }
    }
}
