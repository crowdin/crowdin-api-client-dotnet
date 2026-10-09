using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.AI;
using Crowdin.Api.Core;
using Crowdin.Api.UnitTesting.Resources;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using AiFixtures = Crowdin.Api.UnitTesting.Resources.AI;

namespace Crowdin.Api.UnitTesting.Tests.AI
{
    public class AiApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task ListAiSnippets()
        {
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/ai/settings/snippets", queryParams))
                .ReturnsAsync(ApiResult("ListAiSnippets"));

            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiSnippet> response = await executor.ListAiSnippets(null);

            Assert.Single(response.Data);
            Assert.Equal(2, response.Data[0].Id);
            Assert.Equal("Example snippet", response.Data[0].Description);
            Assert.Equal("%custom:example%", response.Data[0].Placeholder);
            Assert.Equal("Example value", response.Data[0].Value);
        }

        [Fact]
        public async Task AddAiSnippet()
        {
            var request = new AddAiSnippetRequest
            {
                Description = "New snippet",
                Placeholder = "%custom:new%",
                Value = "New value"
            };
            AssertRequest(request, "AddAiSnippet");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPostRequest("/ai/settings/snippets", request, null))
                .ReturnsAsync(ApiResult("AddAiSnippet"));

            var executor = new AiApiExecutor(mockClient.Object);
            AiSnippet response = await executor.AddAiSnippet(null, request);

            Assert.Equal(3, response.Id);
            Assert.Equal("New snippet", response.Description);
            Assert.Equal("%custom:new%", response.Placeholder);
            Assert.Equal("New value", response.Value);
        }

        [Fact]
        public async Task GetAiSnippet()
        {
            const long aiSnippetId = 2;
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest($"/ai/settings/snippets/{aiSnippetId}", null))
                .ReturnsAsync(ApiResult("GetAiSnippet"));

            var executor = new AiApiExecutor(mockClient.Object);
            AiSnippet response = await executor.GetAiSnippet(null, aiSnippetId);

            Assert.Equal(aiSnippetId, response.Id);
            Assert.Equal("Example snippet", response.Description);
            Assert.Equal("%custom:example%", response.Placeholder);
            Assert.Equal("Example value", response.Value);
        }

        [Fact]
        public async Task EditAiSnippet()
        {
            const long aiSnippetId = 2;
            var patches = new[]
            {
                new AiSnippetPatch
                {
                    Operation = PatchOperation.Replace,
                    Path = AiSnippetPatchPath.Value,
                    Value = "Updated value"
                }
            };
            AssertRequest(patches, "EditAiSnippet");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendPatchRequest($"/ai/settings/snippets/{aiSnippetId}", patches, null))
                .ReturnsAsync(ApiResult("EditAiSnippet"));

            var executor = new AiApiExecutor(mockClient.Object);
            AiSnippet response = await executor.EditAiSnippet(null, aiSnippetId, patches);

            Assert.Equal(aiSnippetId, response.Id);
            Assert.Equal("Updated value", response.Value);
            Assert.Equal(DateTimeOffset.Parse("2024-01-15T11:34:40+00:00"), response.UpdatedAt!.Value);
        }

        [Fact]
        public async Task DeleteAiSnippet()
        {
            const long aiSnippetId = 2;
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendDeleteRequest($"/ai/settings/snippets/{aiSnippetId}", null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new AiApiExecutor(mockClient.Object);
            await executor.DeleteAiSnippet(null, aiSnippetId);

            mockClient.Verify(client => client.SendDeleteRequest($"/ai/settings/snippets/{aiSnippetId}", null), Times.Once);
        }

        [Fact]
        public async Task ListAiUsageMembers()
        {
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/ai/usage/members", queryParams))
                .ReturnsAsync(ApiResult("ListAiUsageMembers"));

            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiUsageMember> response = await executor.ListAiUsageMembers();

            Assert.Single(response.Data);
            Assert.Equal(4, response.Data[0].User.Id);
            Assert.Equal("alice", response.Data[0].User.Username);
            Assert.Equal("Alice Example", response.Data[0].User.FullName);
            Assert.Equal(10, response.Data[0].DailyCostLimit);
            Assert.Equal(2.5, response.Data[0].DailyCostSpent);
            Assert.Equal(100, response.Data[0].MonthlyCostLimit);
            Assert.Equal(18.5, response.Data[0].MonthlyCostSpent);
        }

        [Fact]
        public async Task GetAiUsageMember()
        {
            const long memberId = 5;
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest($"/ai/usage/members/{memberId}", null))
                .ReturnsAsync(ApiResult("GetAiUsageMember"));

            var executor = new AiApiExecutor(mockClient.Object);
            AiUsageMember response = await executor.GetAiUsageMember(memberId);

            Assert.Equal(memberId, response.User.Id);
            Assert.Equal("bob", response.User.Username);
            Assert.Equal(5, response.DailyCostLimit);
            Assert.Equal(1.25, response.DailyCostSpent);
            Assert.Equal(50, response.MonthlyCostLimit);
            Assert.Equal(8.5, response.MonthlyCostSpent);
        }

        [Fact]
        public async Task ListAiPromptFineTuningEvents()
        {
            const long aiPromptId = 5;
            const string jobIdentifier = "job";
            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest($"/ai/prompts/{aiPromptId}/fine-tuning/jobs/{jobIdentifier}/events", queryParams))
                .ReturnsAsync(ApiResult("ListAiPromptFineTuningEvents"));

            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiFineTuningEvent> response = await executor.ListAiPromptFineTuningEvents(null, aiPromptId, jobIdentifier);

            Assert.Single(response.Data);
            Assert.Equal("event-1", response.Data[0].Id);
            Assert.Equal("training.step", response.Data[0].Type);
            Assert.Equal("Training step finished", response.Data[0].Message);
            Assert.Equal(3, response.Data[0].Data!.Step);
            Assert.Equal(10, response.Data[0].Data.TotalSteps);
            Assert.Equal(0.25, response.Data[0].Data.TrainingLoss);
            Assert.Equal(0.3, response.Data[0].Data.ValidationLoss);
        }

        [Fact]
        public async Task GetProjectAiSettings()
        {
            const long projectId = 7;
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest($"/projects/{projectId}/ai/settings", null))
                .ReturnsAsync(ApiResult("GetProjectAiSettings"));

            var executor = new AiApiExecutor(mockClient.Object);
            ProjectAiSettings response = await executor.GetProjectAiSettings(projectId);

            Assert.Equal(10, response.EditorSuggestionAiPromptId);
            Assert.Equal(11, response.AlignmentActionAiPromptId);
            Assert.Equal(12, response.QaCheckActionAiPromptId);
            Assert.Equal(13, response.ContextReviewAiPromptId);
        }

        [Fact]
        public async Task ListAllAiProviderModels()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            mockClient
                .Setup(client => client.SendGetRequest("/ai/providers/models", null))
                .ReturnsAsync(ApiResult("ListAllAiProviderModels"));

            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiProviderModelResource> response = await executor.ListAllAiProviderModels(null);

            Assert.Single(response.Data);
            Assert.Equal("gpt-4.1", response.Data[0].Id);
            Assert.Equal("openai", response.Data[0].Provider);
            Assert.Equal("OpenAI", response.Data[0].ProviderName);
            Assert.Equal(8, response.Data[0].ProviderId);
            Assert.Equal(128000, response.Data[0].ContextWindow);
            Assert.Equal(16000, response.Data[0].MaxOutputTokens);
            Assert.True(response.Data[0].SupportsStreaming);
            Assert.True(response.Data[0].SupportsFunctionCalling);
            Assert.True(response.Data[0].SupportsJsonMode);
            Assert.True(response.Data[0].SupportsJsonSchema);
            Assert.True(response.Data[0].SupportsVision);
            Assert.True(response.Data[0].IsCompatibleWithAiLimit);
        }

        private static CrowdinApiResult ApiResult(string key)
        {
            return new CrowdinApiResult
            {
                StatusCode = HttpStatusCode.OK,
                JsonObject = (JObject)JObject.Parse(AiFixtures.ApiResponses)[key]!
            };
        }

        private static void AssertRequest(object request, string key)
        {
            JToken expected = JObject.Parse(AiFixtures.ApiRequests)[key]!;
            JToken actual = JToken.Parse(JsonConvert.SerializeObject(request, JsonSettings));
            Assert.True(JToken.DeepEquals(expected, actual), $"Request {key} did not match its fixture.");
        }
    }
}
