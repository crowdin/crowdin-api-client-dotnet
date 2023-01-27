
using System.Net;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

using Crowdin.Api.Core;
using Crowdin.Api.Reports;
using Crowdin.Api.Tests.Core;

namespace Crowdin.Api.Tests.Reports
{
    public class OrganizationReportsApiTests
    {
        private const int reportId = 1;
        private readonly JObject mockResponseObject = JObject.Parse(@"
                {
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
        ");

        [Fact]
        public async Task GenerateOrganizationReport_GroupTranslationCost()
        {
            var request = new GroupTranslationCostGenerateGroupReportRequest
            {
                Schema = new GroupTranslationCostGenerateGroupReportRequest.RequestSchema
                {
                    Unit = ReportUnit.Words,
                    Currency = ReportCurrency.USD,
                    Format = ReportFormat.Xlsx
                }
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/reports";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            var response = await executor.GenerateOrganizationReport(request);

            Assert.NotNull(response);
            Assert.IsType<GroupReportStatus>(response);
        }

        [Fact]
        public async Task GenerateOrganizationReport_GroupTopMembers()
        {
            var request = new GroupTopMembersGenerateGroupReportRequest
            {
                Schema = new GroupTopMembersGenerateGroupReportRequest.RequestSchema
                {
                    Unit = ReportUnit.Words,
                    LanguageId = "uk",
                    Format = ReportFormat.Xlsx
                }
            };

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/reports";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            var response = await executor.GenerateOrganizationReport(request);

            Assert.NotNull(response);
            Assert.IsType<GroupReportStatus>(response);
        }

        [Fact]
        public async Task CheckOrganizationReportGenerationStatus()
        {
            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/reports/{reportId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            var response = await executor.CheckOrganizationReportGenerationStatus(reportId);

            Assert.NotNull(response);
            Assert.IsType<GroupReportStatus>(response);
        }

        [Fact]
        public async Task DownloadOrganizationReport()
        {
            var mockResponseObject = JObject.Parse(@"
                {
                  ""data"": {
                    ""url"": ""https://production-enterprise-importer.downloads.crowdin.com/992000002/2/14.xliff?response-content-disposition=attachment%3B%20filename%3D%22APP.xliff%22&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAIGJKLQV66ZXPMMEA%2F20190920%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20190920T093121Z&X-Amz-SignedHeaders=host&X-Amz-Expires=3600&X-Amz-Signature=439ebd69a1b7e4c23e6d17891a491c94f832e0c82e4692dedb35a6cd1e624b62"",
                    ""expireIn"": ""2019-09-20T10:31:21+00:00""
                  }
                }
            ");

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/reports/{reportId}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = mockResponseObject
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            var response = await executor.DownloadOrganizationReport(reportId);

            Assert.NotNull(response);
            Assert.IsType<DownloadLink>(response);
        }
    }
}
