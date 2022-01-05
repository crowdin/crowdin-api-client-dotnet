
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Glossaries
{
    public class GlossariesApiExecutor
    {
        private const string BaseUrl = "/glossaries";
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public GlossariesApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }
        
        public GlossariesApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        #region Glossaries

        [PublicAPI]
        public Task<ResponseList<Glossary>> ListGlossaries(
            int limit = 25, int offset = 0, int? userId = null, int? groupId = null)
        {
            return ListGlossaries(new GlossariesListParams(limit, offset, userId, groupId));
        }

        [PublicAPI]
        public async Task<ResponseList<Glossary>> ListGlossaries(GlossariesListParams @params)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseUrl, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<Glossary>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Glossary> AddGlossary(AddGlossaryRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(BaseUrl, request);
            return _jsonParser.ParseResponseObject<Glossary>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Glossary> GetGlossary(int glossaryId)
        {
            string url = FormUrl_GlossaryId(glossaryId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Glossary>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteGlossary(int glossaryId)
        {
            string url = FormUrl_GlossaryId(glossaryId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Glossary {glossaryId} removal failed");
        }

        [PublicAPI]
        public Task<Glossary> EditGlossary(int glossaryId, string newGlossaryName)
        {
            var patches = new[]
            {
                new GlossaryPatch { Value = newGlossaryName }
            };

            return EditGlossary(glossaryId, patches);
        }

        [PublicAPI]
        public async Task<Glossary> EditGlossary(int glossaryId, IEnumerable<GlossaryPatch> patches)
        {
            string url = FormUrl_GlossaryId(glossaryId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Glossary>(result.JsonObject);
        }

        #endregion

        #region Glossaries : Export

        [PublicAPI]
        public async Task<GlossaryExportStatus> ExportGlossary(int glossaryId, ExportGlossaryRequest request)
        {
            var url = $"/glossaries/{glossaryId}/exports";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<GlossaryExportStatus>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<GlossaryExportStatus> CheckGlossaryExportStatus(int glossaryId, string exportId)
        {
            var url = $"/glossaries/{glossaryId}/exports/{exportId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<GlossaryExportStatus>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<DownloadLink> DownloadGlossary(int glossaryId, string exportId)
        {
            var url = $"/glossaries/{glossaryId}/exports/{exportId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        #endregion

        #region Glossaries : Import

        [PublicAPI]
        public async Task<GlossaryImportStatus> ImportGlossary(int glossaryId, ImportGlossaryRequest request)
        {
            var url = $"/glossaries/{glossaryId}/imports";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<GlossaryImportStatus>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<GlossaryImportStatus> CheckGlossaryImportStatus(int glossaryId, string importId)
        {
            var url = $"/glossaries/{glossaryId}/imports/{importId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<GlossaryImportStatus>(result.JsonObject);
        }

        #endregion

        #region Terms

        [PublicAPI]
        public Task<ResponseList<Term>> ListTerms(
            int glossaryId, int? userId = null, string? languageId = null,
            int? translationOfTermId = null, int limit = 25, int offset = 0)
        {
            return ListTerms(glossaryId,
                new TermsListParams(limit, offset, userId, languageId, translationOfTermId));
        }

        [PublicAPI]
        public async Task<ResponseList<Term>> ListTerms(int glossaryId, TermsListParams @params)
        {
            string url = FormUrl_Terms(glossaryId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<Term>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Term> AddTerm(int glossaryId, AddTermRequest request)
        {
            string url = FormUrl_Terms(glossaryId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Term>(result.JsonObject);
        }
        
        [PublicAPI]
        public async Task ClearGlossary(int glossaryId, string? languageId = null, int? translationOfTermId = null)
        {
            string url = FormUrl_Terms(glossaryId);

            var queryParams = new Dictionary<string, string>();
            queryParams.AddParamIfPresent("languageId", languageId);
            queryParams.AddParamIfPresent("translationOfTermId", translationOfTermId);

            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url, queryParams);
            Utils.ThrowIfStatusNot204(statusCode, $"Glossary {glossaryId} cleanup failed");
        }

        [PublicAPI]
        public async Task<Term> GetTerm(int glossaryId, int termId)
        {
            string url = FormUrl_TermId(glossaryId, termId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Term>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteTerm(int glossaryId, int termId)
        {
            string url = FormUrl_TermId(glossaryId, termId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Term {termId} removal failed");
        }

        [PublicAPI]
        public async Task<Term> EditTerm(int glossaryId, int termId, IEnumerable<TermPatch> patches)
        {
            string url = FormUrl_TermId(glossaryId, termId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Term>(result.JsonObject);
        }

        #endregion

        #region Helper methods

        private static string FormUrl_GlossaryId(int glossaryId)
        {
            return $"{BaseUrl}/{glossaryId}";
        }

        private static string FormUrl_Terms(int glossaryId)
        {
            return $"{BaseUrl}/{glossaryId}/terms";
        }

        private static string FormUrl_TermId(int glossaryId, int termId)
        {
            return $"{BaseUrl}/{glossaryId}/terms/{termId}";
        }

        #endregion
    }
}