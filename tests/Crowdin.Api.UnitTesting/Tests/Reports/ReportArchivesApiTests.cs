
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
using Crowdin.Api.Reports;
using Crowdin.Api.UnitTesting.Resources;

namespace Crowdin.Api.UnitTesting.Tests.Reports
{
    public class ReportArchivesApiTests
    {
        private static readonly JsonSerializerSettings JsonSettings = TestUtils.CreateJsonSerializerOptions();

        #region Crowdin

        [Fact]
        public async Task ListReportArchives()
        {
            const int userId = 1;
            const int scopeId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/reports/archives";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            queryParams.Add("scopeType", "project");
            queryParams.Add("scopeId", scopeId.ToString());

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_Archives.Response_Common_Multi)
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            ResponseList<ReportArchive> response = await executor.ListReportArchives(
                userId,
                scopeType: ScopeType.Project,
                scopeId
            );

            Assert_ReportArchive(response.Data.First());
        }

        [Fact]
        public async Task GetReportArchive()
        {
            const int userId = 1;
            const int archiveId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/reports/archives/{archiveId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_Archives.Response_Common_Single)
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            ReportArchive response = await executor.GetReportArchive(userId, archiveId);

            Assert_ReportArchive(response);
        }

        [Fact]
        public async Task DeleteReportArchive()
        {
            const int userId = 1;
            const int archiveId = 2;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/reports/archives/{archiveId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new ReportsApiExecutor(mockClient.Object);
            await executor.DeleteReportArchive(userId, archiveId);
        }

        [Fact]
        public async Task ExportReportArchive()
        {
            const int userId = 1;
            const int archiveId = 2;

            var request = new ExportReportArchiveRequest
            {
                Format = ReportFormat.Json
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Reports_Archives.Request_ExportReportArchive);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/reports/archives/{archiveId}/exports";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_Archives.Response_GroupReportStatus)
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            GroupReportStatus response = await executor.ExportReportArchive(userId, archiveId, request);

            Assert_GroupReportStatus(response);
        }

        [Fact]
        public async Task CheckReportArchiveExportStatus()
        {
            const int userId = 1;
            const int archiveId = 2;
            const string exportId = "id";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/reports/archives/{archiveId}/exports/{exportId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_Archives.Response_GroupReportStatus)
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            GroupReportStatus response = await executor.CheckReportArchiveExportStatus(userId, archiveId, exportId);

            Assert_GroupReportStatus(response);
        }

        [Fact]
        public async Task DownloadReportArchive()
        {
            const int userId = 1;
            const int archiveId = 2;
            const string exportId = "id";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/users/{userId}/reports/archives/{archiveId}/exports/{exportId}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_Archives.Response_DownloadLink)
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            DownloadLink response = await executor.DownloadReportArchive(userId, archiveId, exportId);

            Assert_DownloadLink(response);
        }

        #endregion

        #region Enterprise

        [Fact]
        public async Task ListReportArchivesEnterprise()
        {
            const int scopeId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            const string url = "/reports/archives";

            IDictionary<string, string> queryParams = TestUtils.CreateQueryParamsFromPaging();
            queryParams.Add("scopeType", "project");
            queryParams.Add("scopeId", scopeId.ToString());

            mockClient
                .Setup(client => client.SendGetRequest(url, queryParams))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_Archives.Response_Common_Multi)
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            ResponseList<ReportArchive> response = await executor.ListReportArchives(
                userId: null,
                scopeType: ScopeType.Project,
                scopeId
            );

            Assert_ReportArchive(response.Data.First());
        }

        [Fact]
        public async Task GetReportArchiveEnterprise()
        {
            const int archiveId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/reports/archives/{archiveId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_Archives.Response_Common_Single)
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            ReportArchive response = await executor.GetReportArchive(userId: null, archiveId);

            Assert_ReportArchive(response);
        }

        [Fact]
        public async Task DeleteReportArchiveEnterprise()
        {
            const int archiveId = 1;

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/reports/archives/{archiveId}";

            mockClient
                .Setup(client => client.SendDeleteRequest(url, null))
                .ReturnsAsync(HttpStatusCode.NoContent);

            var executor = new ReportsApiExecutor(mockClient.Object);
            await executor.DeleteReportArchive(userId: null, archiveId);
        }

        [Fact]
        public async Task ExportReportArchiveEnterprise()
        {
            const int archiveId = 1;

            var request = new ExportReportArchiveRequest
            {
                Format = ReportFormat.Json
            };

            string actualRequestJson = JsonConvert.SerializeObject(request, JsonSettings);
            string expectedRequestJson = TestUtils.CompactJson(Reports_Archives.Request_ExportReportArchive);
            Assert.Equal(expectedRequestJson, actualRequestJson);

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/reports/archives/{archiveId}/exports";

            mockClient
                .Setup(client => client.SendPostRequest(url, request, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_Archives.Response_GroupReportStatus)
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            GroupReportStatus response = await executor.ExportReportArchive(userId: null, archiveId, request);

            Assert_GroupReportStatus(response);
        }

        [Fact]
        public async Task CheckReportArchiveExportStatusEnterprise()
        {
            const int archiveId = 1;
            const string exportId = "id";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/reports/archives/{archiveId}/exports/{exportId}";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_Archives.Response_GroupReportStatus)
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            GroupReportStatus response = await executor.CheckReportArchiveExportStatus(userId: null, archiveId, exportId);

            Assert_GroupReportStatus(response);
        }

        [Fact]
        public async Task DownloadReportArchiveEnterprise()
        {
            const int archiveId = 1;
            const string exportId = "id";

            Mock<ICrowdinApiClient> mockClient = TestUtils.CreateMockClientWithDefaultParser();

            var url = $"/reports/archives/{archiveId}/exports/{exportId}/download";

            mockClient
                .Setup(client => client.SendGetRequest(url, null))
                .ReturnsAsync(new CrowdinApiResult
                {
                    StatusCode = HttpStatusCode.OK,
                    JsonObject = JObject.Parse(Reports_Archives.Response_DownloadLink)
                });

            var executor = new ReportsApiExecutor(mockClient.Object);
            DownloadLink response = await executor.DownloadReportArchive(userId: null, archiveId, exportId);

            Assert_DownloadLink(response);
        }

        #endregion

        private static void Assert_ReportArchive(ReportArchive? reportArchive)
        {
            ArgumentNullException.ThrowIfNull(reportArchive);

            Assert.Equal(12, reportArchive.Id);
            Assert.Equal(ScopeType.Project, reportArchive.ScopeType);
            Assert.Equal(35, reportArchive.ScopeId);
            Assert.Equal(35, reportArchive.UserId);
            Assert.Equal("string", reportArchive.Name);
            Assert.StartsWith("https://crowdin.com", reportArchive.WebUrl);
            Assert.Equal(DateTimeOffset.Parse("2019-09-23T11:26:54+00:00"), reportArchive.CreatedAt);
        }

        private static void Assert_GroupReportStatus(GroupReportStatus? status)
        {
            ArgumentNullException.ThrowIfNull(status);

            Assert.Equal("50fb3506-4127-4ba8-8296-f97dc7e3e0c3", status.Identifier);
            Assert.Equal(OperationStatus.Finished, status.Status);
            Assert.Equal(100, status.Progress);

            GroupReportStatus.ReportAttributes? attributes = status.Attributes;
            ArgumentNullException.ThrowIfNull(attributes);
            Assert.Equal(ReportFormat.Xlsx, attributes.Format);
            Assert.Equal("costs-estimation", attributes.ReportName);
            Assert.NotNull(attributes.Schema);

            DateTimeOffset date = DateTimeOffset.Parse("2019-09-23T11:26:54+00:00");
            Assert.Equal(date, status.CreatedAt);
            Assert.Equal(date, status.UpdatedAt);
            Assert.Equal(date, status.StartedAt);
            Assert.Equal(date, status.FinishedAt);
        }

        private static void Assert_DownloadLink(DownloadLink? downloadLink)
        {
            ArgumentNullException.ThrowIfNull(downloadLink);

            Assert.Equal("https://crowdin.com", downloadLink.Url);
            Assert.Equal(DateTimeOffset.Parse("2019-09-20T10:31:21+00:00"), downloadLink.ExpireIn);
        }
    }
}