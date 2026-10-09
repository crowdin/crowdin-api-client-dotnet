#nullable enable

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Placeholders
{
    public class PlaceholdersApiExecutor : IPlaceholdersApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public PlaceholdersApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public PlaceholdersApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List system placeholders.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#operation/api.projects.system-placeholders.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.projects.system-placeholders.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<SystemPlaceholder>> ListSystemPlaceholders(long projectId, int limit = 25, int offset = 0)
        {
            IDictionary<string, string> query = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/projects/{projectId}/system-placeholders", query);
            return _jsonParser.ParseResponseList<SystemPlaceholder>(result.JsonObject);
        }

        /// <summary>
        /// Batch update system placeholders.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#operation/api.projects.system-placeholders.batchPatch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.projects.system-placeholders.batchPatch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<SystemPlaceholder[]> SystemPlaceholdersBatchOperations(long projectId, IEnumerable<SystemPlaceholdersBatchPatch> patches)
        {
            CrowdinApiResult result = await _apiClient.SendPatchRequest($"/projects/{projectId}/system-placeholders", patches);
            return _jsonParser.ParseArray<SystemPlaceholder>(result.JsonObject["data"]!);
        }

        /// <summary>
        /// List custom placeholders.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.custom-placeholders.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<CustomPlaceholder>> ListCustomPlaceholders(int limit = 25, int offset = 0)
        {
            IDictionary<string, string> query = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest("/custom-placeholders", query);
            return _jsonParser.ParseResponseList<CustomPlaceholder>(result.JsonObject);
        }

        /// <summary>
        /// Add a custom placeholder.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.custom-placeholders.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<CustomPlaceholder> AddCustomPlaceholder(AddCustomPlaceholderRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest("/custom-placeholders", request);
            return _jsonParser.ParseResponseObject<CustomPlaceholder>(result.JsonObject);
        }

        /// <summary>
        /// Get a custom placeholder.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.custom-placeholders.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<CustomPlaceholder> GetCustomPlaceholder(long customPlaceholderId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/custom-placeholders/{customPlaceholderId}");
            return _jsonParser.ParseResponseObject<CustomPlaceholder>(result.JsonObject);
        }

        /// <summary>
        /// Edit a custom placeholder.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.custom-placeholders.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<CustomPlaceholder> EditCustomPlaceholder(long customPlaceholderId, IEnumerable<CustomPlaceholderPatch> patches)
        {
            CrowdinApiResult result = await _apiClient.SendPatchRequest($"/custom-placeholders/{customPlaceholderId}", patches);
            return _jsonParser.ParseResponseObject<CustomPlaceholder>(result.JsonObject);
        }

        /// <summary>
        /// Delete a custom placeholder.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.custom-placeholders.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteCustomPlaceholder(long customPlaceholderId)
        {
            HttpStatusCode code = await _apiClient.SendDeleteRequest($"/custom-placeholders/{customPlaceholderId}");
            Utils.ThrowIfStatusNot204(code, $"Custom placeholder {customPlaceholderId} removal failed");
        }

        /// <summary>
        /// List project placeholders.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.projects.placeholders.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<ProjectPlaceholder>> ListProjectPlaceholders(long projectId, int limit = 25, int offset = 0)
        {
            IDictionary<string, string> query = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/projects/{projectId}/placeholders", query);
            return _jsonParser.ParseResponseList<ProjectPlaceholder>(result.JsonObject);
        }

        /// <summary>
        /// Add a project placeholder.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.projects.placeholders.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ProjectPlaceholder> AddProjectPlaceholder(long projectId, AddProjectPlaceholderRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest($"/projects/{projectId}/placeholders", request);
            return _jsonParser.ParseResponseObject<ProjectPlaceholder>(result.JsonObject);
        }

        /// <summary>
        /// Get a project placeholder.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.projects.placeholders.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ProjectPlaceholder> GetProjectPlaceholder(long projectId, long projectPlaceholderId)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest($"/projects/{projectId}/placeholders/{projectPlaceholderId}");
            return _jsonParser.ParseResponseObject<ProjectPlaceholder>(result.JsonObject);
        }

        /// <summary>
        /// Edit a project placeholder.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.projects.placeholders.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ProjectPlaceholder> EditProjectPlaceholder(long projectId, long projectPlaceholderId, IEnumerable<ProjectPlaceholderPatch> patches)
        {
            CrowdinApiResult result = await _apiClient.SendPatchRequest($"/projects/{projectId}/placeholders/{projectPlaceholderId}", patches);
            return _jsonParser.ParseResponseObject<ProjectPlaceholder>(result.JsonObject);
        }

        /// <summary>
        /// Delete a project placeholder.
        /// Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#operation/api.projects.placeholders.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteProjectPlaceholder(long projectId, long projectPlaceholderId)
        {
            HttpStatusCode code = await _apiClient.SendDeleteRequest($"/projects/{projectId}/placeholders/{projectPlaceholderId}");
            Utils.ThrowIfStatusNot204(code, $"Project placeholder {projectPlaceholderId} removal failed");
        }
    }
}
