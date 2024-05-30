
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.SourceStrings
{
    public class SourceStringsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public SourceStringsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public SourceStringsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List strings. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.strings.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.strings.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<SourceString>> ListStrings(
            int projectId, int limit = 25, int offset = 0,
            int? denormalizePlaceholders = null, string? labelIds = null,
            int? fileId = null, int? branchId = null, int? directoryId = null,
            string? croql = null, string? filter = null, StringScope? scope = null)
        {
            return ListStrings(projectId, new StringsListParams(
                denormalizePlaceholders, labelIds, fileId, branchId, directoryId, croql, filter, scope, limit, offset));
        }

        /// <summary>
        /// List strings. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.strings.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.strings.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<SourceString>> ListStrings(int projectId, StringsListParams @params)
        {
            string url = FormUrl_Strings(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<SourceString>(result.JsonObject);
        }

        /// <summary>
        /// Add string. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.strings.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.strings.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<SourceString> AddString(int projectId, AddStringRequest request)
        {
            string url = FormUrl_Strings(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<SourceString>(result.JsonObject);
        }

        /// <summary>
        /// String Batch Operations. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.strings.batchPatch">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.strings.batchPatch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<SourceString>> StringBatchOperations(
            int projectId,
            IEnumerable<StringBatchOpPatch> patches)
        {
            string url = FormUrl_Strings(projectId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseList<SourceString>(result.JsonObject);
        }

        /// <summary>
        /// Get string. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.strings.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.strings.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<SourceString> GetString(int projectId, int stringId, bool denormalizePlaceholders = false)
        {
            IDictionary<string, string>? queryParams = denormalizePlaceholders
                ? new Dictionary<string, string> { { "denormalizePlaceholders", "1" } }
                : null;
            
            string url = FormUrl_StringId(projectId, stringId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseObject<SourceString>(result.JsonObject);
        }

        /// <summary>
        /// Delete string. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.strings.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.strings.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteString(int projectId, int stringId)
        {
            string url = FormUrl_StringId(projectId, stringId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"String {stringId} removal failed");
        }

        /// <summary>
        /// Edit string. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.strings.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.strings.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<SourceString> EditString(int projectId, int stringId, IEnumerable<SourceStringPatch> patches)
        {
            string url = FormUrl_StringId(projectId, stringId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<SourceString>(result.JsonObject);
        }
        
        /// <summary>
        /// Upload strings status. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.strings.uploads.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.strings.uploads.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StringUploadResponseModel> UploadStringsStatus(int projectId, string uploadId)
        {
            string url = FormUrl_StringsUploadId(projectId, uploadId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<StringUploadResponseModel>(result.JsonObject);
        }
        
        /// <summary>
        /// Upload strings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.projects.strings.uploads.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/string-based/#operation/api.projects.strings.uploads.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StringUploadResponseModel> UploadStrings(int projectId, UploadStringsRequest request)
        {
            string url = FormUrl_StringsUpload(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<StringUploadResponseModel>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Strings(int projectId)
        {
            return $"/projects/{projectId}/strings";
        }

        private static string FormUrl_StringId(int projectId, int stringId)
        {
            return $"/projects/{projectId}/strings/{stringId}";
        }
        
        private static string FormUrl_StringsUpload(int projectId)
        {
            return $"/projects/{projectId}/strings/upload";
        }
        
        private static string FormUrl_StringsUploadId(int projectId, string uploadId)
        {
            return $"/projects/{projectId}/strings/uploads/{uploadId}";
        }

        #endregion
    }
}