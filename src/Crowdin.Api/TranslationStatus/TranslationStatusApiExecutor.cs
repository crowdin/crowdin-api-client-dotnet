
using System.Collections.Generic;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.TranslationStatus
{
    public class TranslationStatusApiExecutor
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
            int projectId, int branchId, int limit = 25, int offset = 0)
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
            int projectId, int directoryId, int limit = 25, int offset = 0)
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
            int projectId, int fileId, int limit = 25, int offset = 0)
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
            int projectId, int languageId, int limit = 25, int offset = 0)
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
            int projectId, int limit = 25, int offset = 0)
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
            int projectId, int limit = 25, int offset = 0,
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
        public async Task<ResponseList<QaCheckResource>> ListQaCheckIssues(int projectId, QaCheckIssuesListParams @params)
        {
            var url = $"/projects/{projectId}/qa-checks";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<QaCheckResource>(result.JsonObject);
        }
    }
}