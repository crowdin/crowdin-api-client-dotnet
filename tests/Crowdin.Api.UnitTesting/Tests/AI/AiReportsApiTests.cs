
using System;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.AI;
using Crowdin.Api.Core;
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests.AI
{
    public class AiReportsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        [Fact]
        public async Task GenerateAiReport()
        {
            const int userId = 1;

            var request = new TokensUsageRawDataGenerateAiReport
            {
                Schema = new TokensUsageRawDataGenerateAiReport.GeneralSchema
                {
                    DateFrom = DateTimeOffset.Parse("2024-01-23T07:00:14+00:00").ToLocalTime(),
                    DateTo = DateTimeOffset.Parse("2024-09-27T07:00:14+00:00").ToLocalTime(),
                    Format = AiReportFormat.Json,
                    ProjectIds = [22],
                    PromptIds = [18],
                    UserIds = [1]
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_Reports.GenerateAiReport_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/reports";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Reports.CommonResponses_AiReportGenerationStatus)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiReportGenerationStatus? response = await executor.GenerateAiReport(userId, request);

            Assert_AiReportGenerationStatus(response);
        }

        [Fact]
        public async Task GenerateAiReport_Enterprise()
        {
            var request = new TokensUsageRawDataGenerateAiReport
            {
                Schema = new TokensUsageRawDataGenerateAiReport.GeneralSchema
                {
                    DateFrom = DateTimeOffset.Parse("2024-01-23T07:00:14+00:00").ToLocalTime(),
                    DateTo = DateTimeOffset.Parse("2024-09-27T07:00:14+00:00").ToLocalTime(),
                    Format = AiReportFormat.Json,
                    ProjectIds = [22],
                    PromptIds = [18],
                    UserIds = [1]
                }
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(AI_Reports.GenerateAiReport_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            mockClient
                .Setup(client => client.SendPostRequest("/ai/reports", request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Reports.CommonResponses_AiReportGenerationStatus)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiReportGenerationStatus? response = await executor.GenerateAiReport(userId: null, request);

            Assert_AiReportGenerationStatus(response);
        }

        [Fact]
        public async Task CheckAiReportGenerationStatus()
        {
            const int userId = 1;
            const string aiReportId = "123";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/reports/{aiReportId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Reports.CommonResponses_AiReportGenerationStatus)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiReportGenerationStatus? response = await executor.CheckAiReportGenerationStatus(userId, aiReportId);

            Assert_AiReportGenerationStatus(response);
        }

        [Fact]
        public async Task CheckAiReportGenerationStatus_Enterprise()
        {
            const string aiReportId = "123";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            const string url = $"/ai/reports/{aiReportId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Reports.CommonResponses_AiReportGenerationStatus)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            AiReportGenerationStatus? response = await executor.CheckAiReportGenerationStatus(userId: null, aiReportId);

            Assert_AiReportGenerationStatus(response);
        }

        [Fact]
        public async Task DownloadAiReport()
        {
            const int userId = 1;
            const string aiReportId = "123";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/ai/reports/{aiReportId}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Reports.DownloadAiReport_Response)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            DownloadLink? response = await executor.DownloadAiReport(userId, aiReportId);

            Assert.NotNull(response);
        }

        [Fact]
        public async Task DownloadAiReport_Enterprise()
        {
            const string aiReportId = "123";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            const string url = $"/ai/reports/{aiReportId}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(AI_Reports.DownloadAiReport_Response)
                });

            var executor = new AiApiExecutor(mockClient.Object);
            DownloadLink? response = await executor.DownloadAiReport(userId: null, aiReportId);

            Assert.NotNull(response);
        }

        private static void Assert_AiReportGenerationStatus(AiReportGenerationStatus? status)
        {
            ArgumentNullException.ThrowIfNull(status);

            Assert.Equal("50fb3506-4127-4ba8-8296-f97dc7e3e0c3", status.Identifier);
            Assert.Equal(OperationStatus.Finished, status.Status);
            Assert.Equal(100, status.Progress);

            AiReportGenerationStatus.AttributesObject? attributes = status.Attributes;
            ArgumentNullException.ThrowIfNull(attributes);
            Assert.Equal(AiReportFormat.Json, attributes.Format);
            Assert.Equal(AiReportType.TokensUsageRawData, attributes.ReportType);

            DateTimeOffset date = DateTimeOffset.Parse("2024-01-23T11:26:54+00:00");
            Assert.Equal(date, status.CreatedAt.ToUniversalTime());
            Assert.Equal(date, status.UpdatedAt.ToUniversalTime());
            Assert.Equal(date, status.StartedAt.ToUniversalTime());
            Assert.Equal(date, status.FinishedAt.ToUniversalTime());
        }
    }
}