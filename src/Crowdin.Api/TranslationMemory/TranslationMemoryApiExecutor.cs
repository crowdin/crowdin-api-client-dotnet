
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.TranslationMemory
{
    public class TranslationMemoryApiExecutor
    {
        private const string BaseUrl = "/tms";
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public TranslationMemoryApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public TranslationMemoryApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List TMs. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<TranslationMemory>> ListTms(
            int? userId = null, int? groupId = null, int limit = 25, int offset = 0)
        {
            return ListTms(new TmsListParams(userId, groupId, limit, offset));
        }

        /// <summary>
        /// List TMs. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TranslationMemory>> ListTms(TmsListParams @params)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseUrl, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<TranslationMemory>(result.JsonObject);
        }

        /// <summary>
        /// Add TM. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TranslationMemory> AddTm(AddTmRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(BaseUrl, request);
            return _jsonParser.ParseResponseObject<TranslationMemory>(result.JsonObject);
        }

        /// <summary>
        /// Get TM. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TranslationMemory> GetTm(int tmId)
        {
            string url = FormUrl_TmId(tmId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TranslationMemory>(result.JsonObject);
        }

        /// <summary>
        /// Delete TM. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteTm(int tmId)
        {
            string url = FormUrl_TmId(tmId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Translation Memory {tmId} removal failed");
        }

        /// <summary>
        /// Edit TM. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TranslationMemory> EditTm(int tmId, IEnumerable<TmPatch> patches)
        {
            string url = FormUrl_TmId(tmId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<TranslationMemory>(result.JsonObject);
        }

        /// <summary>
        /// Clear TM. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.segments.clear">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.segments.clear">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task ClearTm(int tmId)
        {
            var url = $"{BaseUrl}/{tmId}/segments";
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Translation Memory {tmId} cleanup failed");
        }

        /// <summary>
        /// Export TM. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.exports.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.exports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TmExportStatus> ExportTm(int tmId, ExportTmRequest request)
        {
            var url = $"{BaseUrl}/{tmId}/exports";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<TmExportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Check TM export status. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.exports.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.exports.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TmExportStatus> CheckTmExportStatus(int tmId, string exportId)
        {
            var url = $"{BaseUrl}/{tmId}/exports/{exportId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TmExportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Download TM. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.exports.download.download">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.exports.download.download">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadTm(int tmId, string exportId)
        {
            var url = $"{BaseUrl}/{tmId}/exports/{exportId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        /// <summary>
        /// Import TM. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.imports.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.imports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TmImportStatus> ImportTm(int tmId, ImportTmRequest request)
        {
            var url = $"{BaseUrl}/{tmId}/imports";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<TmImportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Check TM import status. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.imports.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.imports.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TmImportStatus> CheckTmImportStatus(int tmId, string importId)
        {
            var url = $"{BaseUrl}/{tmId}/imports/{importId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TmImportStatus>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_TmId(int tmId)
        {
            return $"{BaseUrl}/{tmId}";
        }

        #endregion
    }
}