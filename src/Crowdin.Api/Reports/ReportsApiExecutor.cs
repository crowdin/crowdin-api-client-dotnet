﻿
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Reports
{
    public class ReportsApiExecutor : IReportsApiExecutor
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
        
        #region Report Archives
        
        /// <summary>
        /// List Report Archives. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.reports.archives.getMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.reports.archives.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<ReportArchive>> ListReportArchives(
            long? userId,
            ScopeType? scopeType = null,
            long? scopeId = null,
            int limit = 25,
            int offset = 0)
        {
            string url = AddUserIdIfAvailable(userId, "/reports/archives");
            
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddDescriptionEnumValueIfPresent(nameof(scopeType), scopeType);
            queryParams.AddParamIfPresent(nameof(scopeId), scopeId);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<ReportArchive>(result.JsonObject);
        }
        
        /// <summary>
        /// Get Report Archive. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.reports.archives.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.reports.archives.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ReportArchive> GetReportArchive(long? userId, long archiveId)
        {
            string url = AddUserIdIfAvailable(userId, $"/reports/archives/{archiveId}");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<ReportArchive>(result.JsonObject);
        }
        
        /// <summary>
        /// Delete Report Archive. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.reports.archives.delete">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.reports.archives.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteReportArchive(long? userId, long archiveId)
        {
            string url = AddUserIdIfAvailable(userId, $"/reports/archives/{archiveId}");
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Report Archive {archiveId} removal failed");
        }
        
        /// <summary>
        /// Export Report Archive. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.reports.archives.exports.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.reports.archives.exports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GroupReportStatus> ExportReportArchive(
            long? userId,
            long archiveId,
            ExportReportArchiveRequest request)
        {
            string url = AddUserIdIfAvailable(userId, $"/reports/archives/{archiveId}/exports");
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<GroupReportStatus>(result.JsonObject);
        }
        
        /// <summary>
        /// Check Report Archive Export Status. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.reports.archives.exports.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.reports.archives.exports.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GroupReportStatus> CheckReportArchiveExportStatus(
            long? userId,
            long archiveId,
            string exportId)
        {
            string url = AddUserIdIfAvailable(userId, $"/reports/archives/{archiveId}/exports/{exportId}");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<GroupReportStatus>(result.JsonObject);
        }
        
        /// <summary>
        /// Download Report Archive. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.reports.archives.exports.download.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.reports.archives.exports.download.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadReportArchive(long? userId, long archiveId, string exportId)
        {
            string url = AddUserIdIfAvailable(userId, $"/reports/archives/{archiveId}/exports/{exportId}/download");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }
        
        #region Helper methods
        
        private static string AddUserIdIfAvailable(long? userId, string baseUrl)
        {
            return userId.HasValue ? $"/users/{userId}" + baseUrl : baseUrl;
        }
        
        #endregion
        
        #endregion

        #region Group Reports

        /// <summary>
        /// Generate group report. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.groups.reports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GroupReportStatus> GenerateGroupReport(long groupId, GenerateGroupReportRequest request)
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
        public async Task<GroupReportStatus> CheckGroupReportGenerationStatus(long groupId, long reportId)
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
        public async Task<DownloadLink> DownloadGroupReport(long groupId, long reportId)
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
        public async Task<GroupReportStatus> CheckOrganizationReportGenerationStatus(long reportId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/reports/{reportId}");
            return _jsonParser.ParseResponseObject<GroupReportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Download organization report. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.reports.download.download">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadOrganizationReport(long reportId)
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
        public async Task<ReportStatus> GenerateReport(long projectId, GenerateReportRequest request)
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
        public async Task<ReportStatus> CheckReportGenerationStatus(long projectId, string reportId)
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
        public async Task<DownloadLink> DownloadReport(long projectId, string reportId)
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
            long projectId,
            int limit = 25,
            int offset = 0)
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
            long projectId,
            AddReportSettingsTemplateRequest request)
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
            long projectId,
            long reportSettingsTemplateId)
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
            long projectId,
            long reportSettingsTemplateId,
            IEnumerable<ReportSettingsTemplatePatch> patches)
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
        public async Task DeleteReportSettingsTemplate(long projectId, long reportSettingsTemplateId)
        {
            string url = FormUrl_SettingsTemplates(projectId, reportSettingsTemplateId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Report Settings Template {reportSettingsTemplateId} removal failed");
        }

        #region Helper methods

        private static string FormUrl_SettingsTemplates(long projectId)
        {
            return $"/projects/{projectId}/reports/settings-templates";
        }

        private static string FormUrl_SettingsTemplates(long projectId, long reportSettingsTemplateId)
        {
            return $"/projects/{projectId}/reports/settings-templates/{reportSettingsTemplateId}";
        }

        #endregion

        #endregion

        #region User Report Settings Templates

        /// <summary>
        /// List User Report Settings Templates. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Reports/operation/api.users.reports.settings-templates.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Reports/operation/api.users.reports.settings-templates.getMany">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Reports/operation/api.users.reports.settings-templates.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<UserReportSettingsTemplate>> ListUserReportSettingsTemplates(
            long userId,
            int limit = 25,
            int offset = 0)
        {
            string url = FormUrl_UserReportSettingsTemplates(userId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<UserReportSettingsTemplate>(result.JsonObject);
        }

        /// <summary>
        /// Add User Report Settings Template. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Reports/operation/api.users.reports.settings-templates.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Reports/operation/api.users.reports.settings-templates.post">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Reports/operation/api.users.reports.settings-templates.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<UserReportSettingsTemplate> AddUserReportSettingsTemplate(
            long userId,
            AddUserReportSettingsTemplateRequest request)
        {
            string url = FormUrl_UserReportSettingsTemplates(userId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<UserReportSettingsTemplate>(result.JsonObject);
        }

        /// <summary>
        /// Get User Report Settings Template. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Reports/operation/api.users.reports.settings-templates.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Reports/operation/api.users.reports.settings-templates.get">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Reports/operation/api.users.reports.settings-templates.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<UserReportSettingsTemplate> GetUserReportSettingsTemplate(
            long userId,
            long reportSettingsTemplateId)
        {
            string url = FormUrl_UserReportSettingsTemplateId(userId, reportSettingsTemplateId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<UserReportSettingsTemplate>(result.JsonObject);
        }

        /// <summary>
        /// Delete User Report Settings Template. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Reports/operation/api.users.reports.settings-templates.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Reports/operation/api.users.reports.settings-templates.delete">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Reports/operation/api.users.reports.settings-templates.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteUserReportSettingsTemplate(long userId, long reportSettingsTemplateId)
        {
            string url = FormUrl_UserReportSettingsTemplateId(userId, reportSettingsTemplateId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Report Settings Template {reportSettingsTemplateId} removal failed");
        }

        /// <summary>
        /// Edit User Report Settings Template. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Reports/operation/api.users.reports.settings-templates.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Reports/operation/api.users.reports.settings-templates.patch">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Reports/operation/api.users.reports.settings-templates.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<UserReportSettingsTemplate> EditUserReportSettingsTemplate(
            long userId,
            long reportSettingsTemplateId,
            IEnumerable<UserReportSettingsTemplatePatch> patches)
        {
            string url = FormUrl_UserReportSettingsTemplateId(userId, reportSettingsTemplateId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<UserReportSettingsTemplate>(result.JsonObject);
        }
        
        #region Helper methods

        private static string FormUrl_UserReportSettingsTemplates(long userId)
        {
            return $"/users/{userId}/reports/settings-templates";
        }
        
        private static string FormUrl_UserReportSettingsTemplateId(long userId, long reportSettingsTemplateId)
        {
            return $"/users/{userId}/reports/settings-templates/{reportSettingsTemplateId}";
        }
        
        #endregion

        #endregion
    }
}