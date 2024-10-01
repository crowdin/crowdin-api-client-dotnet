
using System;
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Reports;
using Crowdin.Api.Tests.Core;

namespace Crowdin.Api.Tests.Reports
{
    public class ReportsApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();
        
        private const int projectId = 1;
        private const string reportId = "50fb3506-4127-4ba8-8296-f97dc7e3e0c3";
        private readonly JObject mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""identifier"": ""50fb3506-4127-4ba8-8296-f97dc7e3e0c3"",
                    ""status"": ""finished"",
                    ""progress"": 100,
                    ""attributes"": {
                      ""format"": ""xlsx"",
                      ""reportName"": ""costs-estimation"",
                      ""schema"": {}
                    },
                    ""createdAt"": ""2019-09-23T11:26:54+00:00"",
                    ""updatedAt"": ""2019-09-23T11:26:54+00:00"",
                    ""startedAt"": ""2019-09-23T11:26:54+00:00"",
                    ""finishedAt"": ""2019-09-23T11:26:54+00:00"",
                  }
                }
            ");

        [Fact]
        public async Task GenerateReport_PreTranslateEfficiency_General()
        {
            var request = new PreTranslateEfficiencyGenerateReportRequest
            {
                Schema = new PreTranslateEfficiencyGenerateReportRequest.GeneralSchema
                {
                    Unit = ReportUnit.Strings,
                    Format = ReportFormat.Xlsx,
                    PostEditingCategories = new[] { "0-10" },
                    LanguageId = "ach",
                    DateFrom = DateTimeOffset.Parse("2019-09-23T07:00:14+00:00").ToLocalTime(),
                    DateTo = DateTimeOffset.Parse("2019-09-27T07:00:14+00:00").ToLocalTime()
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson =
                TestUtils.CompactJson(Core.Resources.Reports.PreTranslateEfficiency_General_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/reports";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Reports.CommonResponses_ReportStatus)
                });
            
            var executor = new ReportsApiExecutor(mockClient.Object);
            ReportStatus response = await executor.GenerateReport(projectId, request);
            
            Assert_ReportStatus(response);
        }

        [Fact]
        public async Task GenerateReport_PreTranslateEfficiency_ByTask()
        {
            var request = new PreTranslateEfficiencyGenerateReportRequest
            {
                Schema = new PreTranslateEfficiencyGenerateReportRequest.ByTaskSchema
                {
                    Unit = ReportUnit.Strings,
                    Format = ReportFormat.Xlsx,
                    PostEditingCategories = new[] { "0-10" },
                    TaskId = 1
                }
            };
            
            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson =
                TestUtils.CompactJson(Core.Resources.Reports.PreTranslateEfficiency_ByTask_Request);
            Assert.Equal(expectedRequestJson, actualRequestJson);
            
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();
            
            var url = $"/projects/{projectId}/reports";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Core.Resources.Reports.CommonResponses_ReportStatus)
                });
            var executor = new ReportsApiExecutor(mockClient.Object);
            ReportStatus response = await executor.GenerateReport(projectId, request);
            
            Assert_ReportStatus(response);
        }

        [Fact]
        public async Task CheckReportGenerationStatus()
        {
            

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/reports/{reportId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            var response = await executor.CheckReportGenerationStatus(projectId, reportId);

            Assert.NotNull(response);
            Assert.IsType<ReportStatus>(response);
        }

        [Fact]
        public async Task DownloadReport()
        {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""url"": ""https://production-enterprise-importer.downloads.crowdin.com/992000002/2/14.xliff?response-content-disposition=attachment%3B%20filename%3D%22APP.xliff%22&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAIGJKLQV66ZXPMMEA%2F20190920%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20190920T093121Z&X-Amz-SignedHeaders=host&X-Amz-Expires=3600&X-Amz-Signature=439ebd69a1b7e4c23e6d17891a491c94f832e0c82e4692dedb35a6cd1e624b62"",
                    ""expireIn"": ""2019-09-20T10:31:21+00:00""
                  }
                }
            "
            );

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/projects/{projectId}/reports/{reportId}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            var response = await executor.DownloadReport(projectId, reportId);

            Assert.NotNull(response);
            Assert.IsType<DownloadLink>(response);
        }

        private static void Assert_ReportStatus(ReportStatus? response)
        {
            ArgumentNullException.ThrowIfNull(response);
            
            Assert.Equal(reportId, response.Identifier);
            Assert.Equal(OperationStatus.Finished, response.Status);
            Assert.Equal(100, response.Progress);
            
            ReportStatus.ReportAttributes? attributes = response.Attributes;
            ArgumentNullException.ThrowIfNull(attributes);
            Assert.Equal(ReportFormat.Xlsx, attributes.Format);
            Assert.Equal("costs-estimation", attributes.ReportName);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00");
            Assert.Equal(date, response.CreatedAt);
            Assert.Equal(date, response.UpdatedAt);
            Assert.Equal(date, response.StartedAt);
            Assert.Equal(date, response.FinishedAt);
        }
    }
}