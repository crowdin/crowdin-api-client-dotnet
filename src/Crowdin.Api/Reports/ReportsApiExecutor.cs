
using System.Collections.Generic;
using System.Net;
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

        /// <summary>
        /// Generate group report. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.groups.reports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GroupReportStatus> GenerateGroupReport(int groupId, GenerateGroupReportRequest request)
        {
            var url = $"/groups/{groupId}/reports";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<GroupReportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Check group report generation status. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.groups.reports.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GroupReportStatus> CheckGroupReportGenerationStatus(int groupId, int reportId)
        {
            var url = $"/groups/{groupId}/reports/{reportId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<GroupReportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Download group report. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.groups.reports.download.download">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadGroupReport(int groupId, int reportId)
        {
            var url = $"/groups/{groupId}/reports/{reportId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        #endregion

        #region Organization Reports

        /// <summary>
        /// Generate organization report. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.reports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GroupReportStatus> GenerateOrganizationReport(GenerateGroupReportRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest("/reports", request);
            return _jsonParser.ParseResponseObject<GroupReportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Check organization report generation status. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.reports.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GroupReportStatus> CheckOrganizationReportGenerationStatus(int reportId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/reports/{reportId}");
            return _jsonParser.ParseResponseObject<GroupReportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Download organization report. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.reports.download.download">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadOrganizationReport(int reportId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/reports/{reportId}/download");
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        #endregion

        #region Reports

        /// <summary>
        /// Generate report. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.reports.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.reports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ReportStatus> GenerateReport(int projectId, GenerateReportRequest request)
        {
            var url = $"/projects/{projectId}/reports";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<ReportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Check report generation status. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.reports.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.reports.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ReportStatus> CheckReportGenerationStatus(int projectId, string reportId)
        {
            var url = $"/projects/{projectId}/reports/{reportId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<ReportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Download report. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.reports.download.download">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.reports.download.download">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadReport(int projectId, string reportId)
        {
            var url = $"/projects/{projectId}/reports/{reportId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        #endregion

        #region Report Settings Templates

        /// <summary>
        /// List report settings templates. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.reports.settings-templates.getMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.reports.settings-templates.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<ReportSettingsTemplateBase>> ListReportSettingsTemplates(
            int projectId, int limit = 25, int offset = 0)
        {
            var url = $"/projects/{projectId}/reports/settings-templates";
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<ReportSettingsTemplateBase>(result.JsonObject);
        }

        /// <summary>
        /// Add report settings template. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.reports.settings-templates.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.reports.settings-templates.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ReportSettingsTemplateBase> AddReportSettingsTemplate(
            int projectId, AddReportSettingsTemplateRequest request)
        {
            string url = FormUrl_SettingsTemplates(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<ReportSettingsTemplateBase>(result.JsonObject);
        }

        /// <summary>
        /// Get report settings template. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.reports.settings-templates.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.reports.settings-templates.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ReportSettingsTemplateBase> GetReportSettingsTemplate(
            int projectId, int reportSettingsTemplateId)
        {
            string url = FormUrl_SettingsTemplates(projectId, reportSettingsTemplateId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<ReportSettingsTemplateBase>(result.JsonObject);
        }

        /// <summary>
        /// Edit report settings template. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.reports.settings-templates.patch">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.reports.settings-templates.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ReportSettingsTemplateBase> EditReportSettingsTemplate(
            int projectId, int reportSettingsTemplateId, IEnumerable<ReportSettingsTemplatePatch> patches)
        {
            string url = FormUrl_SettingsTemplates(projectId, reportSettingsTemplateId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<ReportSettingsTemplateBase>(result.JsonObject);
        }

        /// <summary>
        /// Delete report settings template. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.settings-templates.delete">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.settings-templates.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteReportSettingsTemplate(int projectId, int reportSettingsTemplateId)
        {
            string url = FormUrl_SettingsTemplates(projectId, reportSettingsTemplateId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Report Settings Template {reportSettingsTemplateId} removal failed");
        }

        #region Helper methods

        private static string FormUrl_SettingsTemplates(int projectId)
        {
            return $"/projects/{projectId}/reports/settings-templates";
        }

        private static string FormUrl_SettingsTemplates(int projectId, int reportSettingsTemplateId)
        {
            return $"/projects/{projectId}/reports/settings-templates/{reportSettingsTemplateId}";
        }

        #endregion

        #endregion
    }
}