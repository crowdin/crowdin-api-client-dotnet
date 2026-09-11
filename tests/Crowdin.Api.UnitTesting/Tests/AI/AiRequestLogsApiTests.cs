using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.AI;
using Crowdin.Api.Core;
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests.AI
{
    public class AiRequestLogsApiTests
    {
        [Fact]
        public async Task ListAiRequestLogs()
        {
            const long userId = 1;

            var @params = new AiRequestLogsListParams
            {
                Limit = 10,
                Offset = 2,
                RequestId = "9d3b1c4e-2f3a-4b5c-8d6e-7f8a9b0c1d2e",
                ProjectId = 8,
                UserId = 42,
                AiProviderId = 3,
                Model = "gpt-5.6-sol",
                SourceAction = AiRequestLogSourceAction.AiGateway,
                PromptAction = "pre_translate",
                Statuses = new[] { AiRequestLogStatus.Success, AiRequestLogStatus.Error },
                SystemCredentials = false,
                IsAutoTriggered = true,
                TokenName = "Token name",
                OauthClientId = "gpbccUFxAKZDrLm5Nq8t",
                CreatedAfter = DateTimeOffset.Parse("2026-01-01T00:00:00+00:00"),
                CreatedBefore = DateTimeOffset.Parse("2026-01-02T00:00:00+00:00")
            };

            IDictionary<string, string> queryParams = @params.ToQueryParams();

            Assert.Equal("10", queryParams["limit"]);
            Assert.Equal("2", queryParams["offset"]);
            Assert.Equal("9d3b1c4e-2f3a-4b5c-8d6e-7f8a9b0c1d2e", queryParams["requestId"]);
            Assert.Equal("8", queryParams["projectId"]);
            Assert.Equal("42", queryParams["userId"]);
            Assert.Equal("3", queryParams["aiProviderId"]);
            Assert.Equal("gpt-5.6-sol", queryParams["model"]);
            Assert.Equal("ai_gateway", queryParams["sourceAction"]);
            Assert.Equal("pre_translate", queryParams["promptAction"]);
            Assert.Equal("success,error", queryParams["statuses"]);
            Assert.Equal("false", queryParams["systemCredentials"]);
            Assert.Equal("true", queryParams["isAutoTriggered"]);
            Assert.Equal("Token name", queryParams["tokenName"]);
            Assert.Equal("gpbccUFxAKZDrLm5Nq8t", queryParams["oauthClientId"]);
            Assert.Equal("2026-01-01T00:00:00+00:00", queryParams["createdAfter"]);
            Assert.Equal("2026-01-02T00:00:00+00:00", queryParams["createdBefore"]);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/request-logs";

            mockClient
                .Setup(client => client.SendGetRequest(
                    url,
                    It.Is<IDictionary<string, string>>(actual => actual.SequenceEqual(queryParams))))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_RequestLogs.ListAiRequestLogs_Response)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiRequestLog> response = await executor.ListAiRequestLogs(userId, @params);

            Assert.Equal(2, response.Data.Count);
            Assert_AiRequestLog(response.Data[0]);
            Assert_PendingAiRequestLog(response.Data[1]);
        }

        [Fact]
        public async Task ListAiRequestLogs_Enterprise()
        {
            var @params = new AiRequestLogsListParams
            {
                Statuses = new[] { AiRequestLogStatus.Pending }
            };

            IDictionary<string, string> queryParams = @params.ToQueryParams();

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendGetRequest(
                    "/ai/request-logs",
                    It.Is<IDictionary<string, string>>(actual => actual.SequenceEqual(queryParams))))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_RequestLogs.ListAiRequestLogs_Response)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            ResponseList<AiRequestLog> response = await executor.ListAiRequestLogs(userId: null, @params);

            Assert.Equal(2, response.Data.Count);
            Assert_AiRequestLog(response.Data[0]);
        }

        private static void Assert_AiRequestLog(AiRequestLog log)
        {
            Assert.Equal(12345, log.Id);
            Assert.Equal("9d3b1c4e-2f3a-4b5c-8d6e-7f8a9b0c1d2e", log.RequestId);
            Assert.Equal(DateTimeOffset.Parse("2026-01-01T10:00:00+00:00"), log.CreatedAt);
            Assert.Equal(AiRequestLogStatus.Success, log.Status);
            Assert.Equal(200, log.HttpStatus);
            Assert.Equal("gpt-5.6-sol", log.Model);
            Assert.Equal(AiRequestLogSourceAction.AiGateway, log.SourceAction);
            Assert.Equal("pre_translate", log.PromptAction);
            Assert.False(log.SystemCredentials);
            Assert.False(log.IsAutoTriggered);
            Assert.Equal(842, log.DurationMs);
            Assert.Equal(512, log.InputTokens);
            Assert.Equal(128, log.OutputTokens);
            Assert.Equal(0.012345f, log.TotalCost);
            Assert.Equal(42, log.UserId);
            Assert.Equal(8, log.ProjectId);
            Assert.Equal(5, log.PromptId);
            Assert.Equal(3, log.AiProviderId);
            Assert.Equal("Token name", log.TokenName);
            Assert.Equal("gpbccUFxAKZDrLm5Nq8t", log.OauthClientId);
            Assert.Equal("AI Pipeline", log.OauthClientName);
            Assert.Equal("203.0.113.42", log.Ip);
            Assert.Equal("Mozilla/5.0", log.UserAgent);
            Assert.Null(log.Error);
        }

        private static void Assert_PendingAiRequestLog(AiRequestLog log)
        {
            Assert.Equal(12346, log.Id);
            Assert.Equal(AiRequestLogStatus.Pending, log.Status);
            Assert.Equal(AiRequestLogSourceAction.AiProxy, log.SourceAction);
            Assert.Null(log.HttpStatus);
            Assert.Null(log.PromptAction);
            Assert.True(log.SystemCredentials);
            Assert.True(log.IsAutoTriggered);
            Assert.Null(log.DurationMs);
            Assert.Null(log.InputTokens);
            Assert.Null(log.OutputTokens);
            Assert.Null(log.TotalCost);
            Assert.Null(log.UserId);
            Assert.Null(log.ProjectId);
            Assert.Null(log.PromptId);
            Assert.Null(log.TokenName);
            Assert.Null(log.OauthClientId);
            Assert.Null(log.OauthClientName);
            Assert.Null(log.Ip);
            Assert.Null(log.UserAgent);
            Assert.Null(log.Error);
        }
    }
}
