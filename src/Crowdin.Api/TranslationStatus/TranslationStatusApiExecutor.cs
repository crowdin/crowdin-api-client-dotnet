
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.TranslationStatus
{
    public class TranslationStatusApiExecutor : ITranslationStatusApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public TranslationStatusApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public TranslationStatusApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// Get branch progress. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.branches.languages.progress.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.branches.languages.progress.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<ProgressResource>> GetBranchProgress(
            long projectId,
            long branchId,
            int limit = 25,
            int offset = 0)
        {
            var url = $"/projects/{projectId}/branches/{branchId}/languages/progress";
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<ProgressResource>(result.JsonObject);
        }

        /// <summary>
        /// . Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.directories.languages.progress.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.directories.languages.progress.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<ProgressResource>> GetDirectoryProgress(
            long projectId,
            long directoryId,
            int limit = 25,
            int offset = 0)
        {
            var url = $"/projects/{projectId}/directories/{directoryId}/languages/progress";
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<ProgressResource>(result.JsonObject);
        }

        /// <summary>
        /// Get file progress. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.files.languages.progress.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.files.languages.progress.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<FileProgressResource>> GetFileProgress(
            long projectId,
            long fileId,
            int limit = 25,
            int offset = 0)
        {
            var url = $"/projects/{projectId}/files/{fileId}/languages/progress";
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<FileProgressResource>(result.JsonObject);
        }

        /// <summary>
        /// Get language progress. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.languages.files.progress.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.languages.files.progress.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<LanguageProgressResource>> GetLanguageProgress(
            long projectId,
            string languageId,
            int limit = 25,
            int offset = 0)
        {
            var url = $"/projects/{projectId}/languages/{languageId}/progress";
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<LanguageProgressResource>(result.JsonObject);
        }

        /// <summary>
        /// Get project progress. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.languages.progress.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.languages.progress.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<ProgressResource>> GetProjectProgress(
            long projectId,
            int limit = 25,
            int offset = 0)
        {
            var url = $"/projects/{projectId}/languages/progress";
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<ProgressResource>(result.JsonObject);
        }

        /// <summary>
        /// List QA check issues. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.qa-checks.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.qa-checks.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<QaCheckResource>> ListQaCheckIssues(
            long projectId,
            int limit = 25,
            int offset = 0,
            ICollection<QaCheckIssueCategory>? categories = null,
            ICollection<QaCheckIssueValidationType>? validation = null,
            ICollection<string>? languageIds = null)
        {
            return ListQaCheckIssues(projectId,
                new QaCheckIssuesListParams(limit, offset, categories, validation, languageIds));
        }

        /// <summary>
        /// List QA check issues. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.qa-checks.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.qa-checks.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<QaCheckResource>> ListQaCheckIssues(long projectId, QaCheckIssuesListParams @params)
        {
            var url = $"/projects/{projectId}/qa-checks";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<QaCheckResource>(result.JsonObject);
        }

        /// <summary>
        /// Revalidate QA Checks. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Translation-Status/operation/api.projects.qa-checks.revalidate.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Translation-Status/operation/api.projects.qa-checks.revalidate.post">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Translation-Status/operation/api.projects.qa-checks.revalidate.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<QaCheckRevalidationStatus> RevalidateQaChecks(long projectId, RevalidateQaChecksRequest request)
        {
            var url = $"/projects/{projectId}/qa-checks/revalidate";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<QaCheckRevalidationStatus>(result.JsonObject);
        }

        /// <summary>
        /// Get QA Checks Revalidation Status. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Translation-Status/operation/api.projects.qa-checks.revalidate.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Translation-Status/operation/api.projects.qa-checks.revalidate.get">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Translation-Status/operation/api.projects.qa-checks.revalidate.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<QaCheckRevalidationStatus> GetQaChecksRevalidationStatus(long projectId, string revalidationId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/projects/{projectId}/qa-checks/revalidate/{revalidationId}");
            return _jsonParser.ParseResponseObject<QaCheckRevalidationStatus>(result.JsonObject);
        }

        /// <summary>
        /// Cancel QA Checks Revalidation. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Translation-Status/operation/api.projects.qa-checks.revalidate.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Translation-Status/operation/api.projects.qa-checks.revalidate.delete">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Translation-Status/operation/api.projects.qa-checks.revalidate.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task CancelQaChecksRevalidation(long projectId, string revalidationId)
        {
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest($"/projects/{projectId}/qa-checks/revalidate/{revalidationId}");
            Utils.ThrowIfStatusNot204(statusCode, $"QA checks revalidation {revalidationId} cancellation failed");
        }
    }
}