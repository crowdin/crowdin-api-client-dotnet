
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.TranslationMemory
{
    public class TranslationMemoryApiExecutor : ITranslationMemoryApiExecutor
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
            long? userId = null,
            long? groupId = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null)
        {
            return ListTms(new TmsListParams(userId, groupId, limit, offset, orderBy));
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
        public async Task<TranslationMemory> GetTm(long tmId)
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
        public async Task DeleteTm(long tmId)
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
        public async Task<TranslationMemory> EditTm(long tmId, IEnumerable<TmPatch> patches)
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
        public async Task ClearTm(long tmId)
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
        public async Task<TmExportStatus> ExportTm(long tmId, ExportTmRequest request)
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
        public async Task<TmExportStatus> CheckTmExportStatus(long tmId, string exportId)
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
        public async Task<DownloadLink> DownloadTm(long tmId, string exportId)
        {
            var url = $"{BaseUrl}/{tmId}/exports/{exportId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        /// <summary>
        /// Concordance search in TMs. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.tms.concordance.post">Crowdin API</a>
        /// <a href="hhttps://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.tms.concordance.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TmConcordanceResultResource>> ConcordanceSearch(
            long projectId,
            ConcordanceSearchRequest request)
        {
            var url = $"/projects/{projectId}/tms/concordance";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseList<TmConcordanceResultResource>(result.JsonObject);
        }

        /// <summary>
        /// Import TM. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.tms.imports.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.tms.imports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TmImportStatus> ImportTm(long tmId, ImportTmRequest request)
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
        public async Task<TmImportStatus> CheckTmImportStatus(long tmId, string importId)
        {
            var url = $"{BaseUrl}/{tmId}/imports/{importId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TmImportStatus>(result.JsonObject);
        }
        
        #region Segments
        
        /// <summary>
        /// List TM Segments. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.tms.segments.getMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.tms.segments.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TmSegmentResource>> ListTmSegments(
            long tmId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null)
        {
            string url = FormUrl_TmSegments(tmId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddSortingRulesIfPresent(orderBy);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<TmSegmentResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Create TM Segment. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.tms.segments.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.tms.segments.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TmSegmentResource> CreateTmSegment(long tmId, CreateTmSegmentRequest request)
        {
            string url = FormUrl_TmSegments(tmId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<TmSegmentResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Get TM Segment. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.tms.segments.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.tms.segments.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TmSegmentResource> GetTmSegment(long tmId, long segmentId)
        {
            string url = FormUrl_TmSegmentId(tmId, segmentId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TmSegmentResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Delete TM Segment. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.tms.segments.delete">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.tms.segments.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteTmSegment(long tmId, long segmentId)
        {
            string url = FormUrl_TmSegmentId(tmId, segmentId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"TM Segment {segmentId} removal failed");
        }
        
        /// <summary>
        /// Delete TM Segment Record. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.tms.segments.records.delete">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.tms.segments.records.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteTmSegmentRecord(long tmId, long segmentId, long recordId)
        {
            string url = FormUrl_TmSegmentRecordId(tmId, segmentId, recordId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"TM Segment Record {recordId} removal failed");
        }
        
        /// <summary>
        /// Edit TM Segment Record. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.tms.segments.records.patch">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.tms.segments.records.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TmSegmentResource> EditTmSegmentRecord(
            long tmId,
            long segmentId,
            long recordId,
            IEnumerable<TmSegmentRecordPatch> patches)
        {
            string url = FormUrl_TmSegmentRecordId(tmId, segmentId, recordId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<TmSegmentResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Create TM Segment Records. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.tms.segments.records.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.tms.segments.records.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TmSegmentResource> CreateTmSegmentRecords(
            long tmId,
            long segmentId,
            CreateTmSegmentRecordsRequest request)
        {
            string url = FormUrl_TmSegmentRecords(tmId, segmentId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<TmSegmentResource>(result.JsonObject);
        }

        #endregion

        #region Helper methods

        private static string FormUrl_TmId(long tmId)
        {
            return $"{BaseUrl}/{tmId}";
        }

        #region Segments

        private static string FormUrl_TmSegments(long tmId)
        {
            return $"/tms/{tmId}/segments";
        }

        private static string FormUrl_TmSegmentId(long tmId, long segmentId)
        {
            return $"/tms/{tmId}/segments/{segmentId}";
        }

        private static string FormUrl_TmSegmentRecords(long tmId, long segmentId)
        {
            return $"/tms/{tmId}/segments/{segmentId}/records";
        }

        private static string FormUrl_TmSegmentRecordId(long tmId, long segmentId, long recordId)
        {
            return $"/tms/{tmId}/segments/{segmentId}/records/{recordId}";
        }

        #endregion

        #endregion
    }
}