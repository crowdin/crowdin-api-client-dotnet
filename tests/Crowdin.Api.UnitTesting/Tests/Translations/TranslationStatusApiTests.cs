
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.TranslationStatus;

namespace Crowdin.Api.UnitTesting.Tests.Translations
{
    public class TranslationStatusApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        [Fact]
        public async Task GetLanguageProgress()
        {
            const int projectId = 1;
            const string languageId = "es";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest(
                    $"/projects/{projectId}/languages/{languageId}/progress", queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Translations.GetLanguageStatusResponse)
                });

            var executor = new TranslationStatusApiExecutor(mockClient.Object);

            ResponseList<LanguageProgressResource> response = await executor.GetLanguageProgress(projectId, languageId);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task RevalidateQaChecks()
        {
            const long projectId = 1;

            var request = new RevalidateQaChecksRequest
            {
                QaCheckCategories =
                [
                    QaCheckRevalidationCategory.Terms,
                    QaCheckRevalidationCategory.Ai
                ],
                LanguageIds = ["uk", "fr"],
                FailedOnly = true
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Resources.Translations.RevalidateQaChecks_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPostRequest(
                    $"/projects/{projectId}/qa-checks/revalidate", It.IsAny<object>(), null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.Accepted,
                    JsonObject = JObject.Parse(Resources.Translations.RevalidateQaChecks_Response)
                });

            var executor = new TranslationStatusApiExecutor(mockClient.Object);
            QaCheckRevalidationStatus result = await executor.RevalidateQaChecks(projectId, request);

            Assert.NotNull(result);
            Assert.Equal("9e7de270-4f83-47a3-b2e9-8b49f1b2d5c3", result.Identifier);
            Assert.Equal(OperationStatus.Created, result.Status);
            Assert.Equal(0, result.Progress);
            Assert.NotNull(result.Attributes);
            Assert.Equal(["uk", "fr"], result.Attributes.LanguageIds);
            Assert.Equal([
                QaCheckRevalidationCategory.Terms,
                QaCheckRevalidationCategory.Ai
            ], result.Attributes.QaCheckCategories);
            Assert.True(result.Attributes.FailedOnly);
            Assert.Null(result.StartedAt);
            Assert.Null(result.FinishedAt);
        }

        [Fact]
        public async Task GetQaChecksRevalidationStatus()
        {
            const long projectId = 1;
            const string revalidationId = "9e7de270-4f83-47a3-b2e9-8b49f1b2d5c3";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest(
                    $"/projects/{projectId}/qa-checks/revalidate/{revalidationId}", null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Resources.Translations.GetQaChecksRevalidationStatus_Response)
                });

            var executor = new TranslationStatusApiExecutor(mockClient.Object);
            QaCheckRevalidationStatus result = await executor.GetQaChecksRevalidationStatus(projectId, revalidationId);

            Assert.NotNull(result);
            Assert.Equal(revalidationId, result.Identifier);
            Assert.Equal(OperationStatus.Finished, result.Status);
            Assert.Equal(100, result.Progress);
            Assert.NotNull(result.Attributes);
            Assert.NotNull(result.StartedAt);
            Assert.NotNull(result.FinishedAt);
        }

        [Fact]
        public async Task CancelQaChecksRevalidation()
        {
            const long projectId = 1;
            const string revalidationId = "9e7de270-4f83-47a3-b2e9-8b49f1b2d5c3";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendDeleteRequest(
                    $"/projects/{projectId}/qa-checks/revalidate/{revalidationId}", null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new TranslationStatusApiExecutor(mockClient.Object);
            await executor.CancelQaChecksRevalidation(projectId, revalidationId);

            mockClient.Verify(
                client => client.SendDeleteRequest(
                    $"/projects/{projectId}/qa-checks/revalidate/{revalidationId}", null),
                Times.Once);
        }
    }
}
