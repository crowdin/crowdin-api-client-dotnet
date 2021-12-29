
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    public class ReportsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public ReportsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public ReportsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        #region Group Reports

        [PublicAPI]
        public async Task<GroupReportStatus> GenerateGroupReport(int groupId, GenerateGroupReportRequest request)
        {
            var url = $"/groups/{groupId}/reports";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<GroupReportStatus>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<GroupReportStatus> CheckGroupReportGenerationStatus(int groupId, int reportId)
        {
            var url = $"/groups/{groupId}/reports/{reportId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<GroupReportStatus>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<DownloadLink> DownloadGroupReport(int groupId, int reportId)
        {
            var url = $"/groups/{groupId}/reports/{reportId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        #endregion

        #region Organization Reports

        [PublicAPI]
        public async Task<GroupReportStatus> GenerateOrganizationReport(GenerateGroupReportRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest("/reports", request);
            return _jsonParser.ParseResponseObject<GroupReportStatus>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<GroupReportStatus> CheckOrganizationReportGenerationStatus(int reportId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/reports/{reportId}");
            return _jsonParser.ParseResponseObject<GroupReportStatus>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<DownloadLink> DownloadOrganizationReport(int reportId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/reports/{reportId}/download");
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        #endregion

        #region Reports

        [PublicAPI]
        public async Task<ReportStatus> GenerateReport(int projectId, GenerateReportRequest request)
        {
            var url = $"/projects/{projectId}/reports";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<ReportStatus>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<ReportStatus> CheckReportGenerationStatus(int projectId, string reportId)
        {
            var url = $"/projects/{projectId}/reports/{reportId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<ReportStatus>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<DownloadLink> DownloadReport(int projectId, string reportId)
        {
            var url = $"/projects/{projectId}/reports/{reportId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        #endregion
    }
}