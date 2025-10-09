using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.SourceStrings
{
    public class SourceStringsApiExecutor : ISourceStringsApiExecutor
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
            long projectId,
            int limit = 25,
            int offset = 0,
            int? denormalizePlaceholders = null,
            string? labelIds = null,
            long? fileId = null,
            long? branchId = null,
            long? directoryId = null,
            long? taskId = null,
            string? croql = null,
            string? filter = null,
            StringScope? scope = null,
            IEnumerable<SortingRule>? orderBy = null)
        {
            return ListStrings(
                projectId,
                new StringsListParams(
                    denormalizePlaceholders, labelIds, fileId, branchId,
                    directoryId, taskId, croql, filter, scope, limit, offset, orderBy));
        }

        /// <summary>
        /// List strings. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.strings.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.strings.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<SourceString>> ListStrings(long projectId, StringsListParams @params)
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
        public async Task<SourceString> AddString(long projectId, AddStringRequest request)
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
            long projectId,
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
        public async Task<SourceString> GetString(long projectId, long stringId, bool denormalizePlaceholders = false)
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
        public async Task DeleteString(long projectId, long stringId)
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
        public async Task<SourceString> EditString(long projectId, long stringId, IEnumerable<SourceStringPatch> patches)
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
        public async Task<StringUploadResponseModel> UploadStringsStatus(long projectId, string uploadId)
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
        public async Task<StringUploadResponseModel> UploadStrings(long projectId, UploadStringsRequest request)
        {
            string url = FormUrl_StringsUpload(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<StringUploadResponseModel>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Strings(long projectId)
        {
            return $"/projects/{projectId}/strings";
        }

        private static string FormUrl_StringId(long projectId, long stringId)
        {
            return $"/projects/{projectId}/strings/{stringId}";
        }
        
        private static string FormUrl_StringsUpload(long projectId)
        {
            return $"/projects/{projectId}/strings/uploads";
        }
        
        private static string FormUrl_StringsUploadId(long projectId, string uploadId)
        {
            return $"/projects/{projectId}/strings/uploads/{uploadId}";
        }

        #endregion
    }
}