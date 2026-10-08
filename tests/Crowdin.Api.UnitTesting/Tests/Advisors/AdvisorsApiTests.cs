using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Advisors;
using Crowdin.Api.Core;
using Crowdin.Api.UnitTesting.Resources;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using AdvisorFixtures = Crowdin.Api.UnitTesting.Resources.Advisors;

namespace Crowdin.Api.UnitTesting.Tests.Advisors
{
    public class AdvisorsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task CreateAdvisorCheck()
        {
            const long projectId = 7;
            var request = new CreateAdvisorCheckRequest { Category = "context" };
            AssertRequest(request, "CreateAdvisorCheck");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPostRequest($"/projects/{projectId}/advisors/checks", request, null))
                .ReturnsAsync(ApiResult("CreateAdvisorCheck"));

            var executor = new AdvisorsApiExecutor(mockClient.Object);
            AdvisorCheck response = await executor.CreateAdvisorCheck(projectId, request);

            Assert.Equal("check-created", response.Identifier);
            Assert.Equal(AdvisorCheckStatus.InProgress, response.Status);
            Assert.Equal(25, response.Progress);
            Assert.Equal("context", response.Attributes.Category);
            Assert.Equal("context", response.Attributes.Inspectors!.Single().Key);
        }

        [Fact]
        public async Task GetAdvisorCheckStatus()
        {
            const long projectId = 7;
            const string checkId = "check-status";
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/advisors/checks/{checkId}", null))
                .ReturnsAsync(ApiResult("GetAdvisorCheckStatus"));

            var executor = new AdvisorsApiExecutor(mockClient.Object);
            AdvisorCheck response = await executor.GetAdvisorCheckStatus(projectId, checkId);

            Assert.Equal(checkId, response.Identifier);
            Assert.Equal(AdvisorCheckStatus.Done, response.Status);
            Assert.Equal(100, response.Progress);
            Assert.Equal("context", response.Attributes.Category);
        }

        [Fact]
        public async Task ListAdvisorInsights()
        {
            const long projectId = 7;
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/advisors/insights", queryParams))
                .ReturnsAsync(ApiResult("ListAdvisorInsights"));

            var executor = new AdvisorsApiExecutor(mockClient.Object);
            AdvisorInsightsResponseList response = await executor.ListAdvisorInsights(projectId);

            Assert.Single(response.Data);
            Assert.Equal(1, response.Pagination!.Total);
            Assert.Equal("context", response.Data[0].InspectorKey);
            Assert.Equal("quality", response.Data[0].Category);
            Assert.False(response.Data[0].IsDismissed);
            Assert.Equal(AdvisorInsightOutcome.Flagged, response.Data[0].Outcome);
            Assert.Equal(AdvisorInsightSeverity.High, response.Data[0].Severity);
            Assert.Equal("Add context", response.Data[0].Payload!["summary"]!.Value<string>());
        }

        [Fact]
        public async Task EditAdvisorInsight()
        {
            const long projectId = 7;
            const long insightId = 4;
            var patches = new[]
            {
                new EditAdvisorInsightPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = EditAdvisorInsightPatchPath.IsDismissed,
                    Value = true
                }
            };
            AssertRequest(patches, "EditAdvisorInsight");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPatchRequest($"/projects/{projectId}/advisors/insights/{insightId}", patches, null))
                .ReturnsAsync(ApiResult("EditAdvisorInsight"));

            var executor = new AdvisorsApiExecutor(mockClient.Object);
            AdvisorInsight response = await executor.EditAdvisorInsight(projectId, insightId, patches);

            Assert.Equal(insightId, response.Id);
            Assert.True(response.IsDismissed);
            Assert.Equal(AdvisorInsightOutcome.Clear, response.Outcome);
            Assert.Equal(AdvisorInsightSeverity.Medium, response.Severity);
        }

        [Fact]
        public async Task CreateOrUpdateApplicationAdvisorInsight()
        {
            const long projectId = 7;
            const string applicationIdentifier = "app-id";
            const string moduleKey = "module";
            var request = new CreateOrUpdateApplicationAdvisorInsightRequest
            {
                Outcome = AdvisorInsightOutcome.Clear,
                Payload = new JObject()
            };
            AssertRequest(request, "CreateOrUpdateApplicationAdvisorInsight");

            string url = $"/projects/{projectId}/applications/{applicationIdentifier}/modules/{moduleKey}/advisors/insights";
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPutRequest(url, request))
                .ReturnsAsync(ApiResult("CreateOrUpdateApplicationAdvisorInsight"));

            var executor = new AdvisorsApiExecutor(mockClient.Object);
            await executor.CreateOrUpdateApplicationAdvisorInsight(projectId, applicationIdentifier, moduleKey, request);

            mockClient.Verify(client => client.SendPutRequest(url, request), Times.Once);
        }

        private static CrowdinApiResult ApiResult(string key)
        {
            return new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = ResponseJson(key)
            };
        }

        private static JObject ResponseJson(string key)
        {
            return (JObject)JObject.Parse(AdvisorFixtures.ApiResponses)[key]!;
        }

        private static void AssertRequest(object request, string key)
        {
            JToken expected = JObject.Parse(AdvisorFixtures.ApiRequests)[key]!;
            JToken actual = JToken.Parse(JsonConvert.SerializeObject(request, JsonSettings));
            Assert.True(JToken.DeepEquals(expected, actual), $"Request {key} did not match its fixture.");
        }
    }
}
