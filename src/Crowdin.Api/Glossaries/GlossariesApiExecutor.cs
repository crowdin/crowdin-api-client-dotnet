﻿
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Glossaries
{
    public class GlossariesApiExecutor : IGlossariesApiExecutor
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

        /// <summary>
        /// List glossaries. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<Glossary>> ListGlossaries(
            int limit = 25,
            int offset = 0,
            long? userId = null,
            long? groupId = null,
            IEnumerable<SortingRule>? orderBy = null)
        {
            return ListGlossaries(new GlossariesListParams(limit, offset, userId, groupId, orderBy));
        }

        /// <summary>
        /// List glossaries. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Glossary>> ListGlossaries(GlossariesListParams @params)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseUrl, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<Glossary>(result.JsonObject);
        }

        /// <summary>
        /// Add glossary. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Glossary> AddGlossary(AddGlossaryRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(BaseUrl, request);
            return _jsonParser.ParseResponseObject<Glossary>(result.JsonObject);
        }

        /// <summary>
        /// Get glossary. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Glossary> GetGlossary(long glossaryId)
        {
            string url = FormUrl_GlossaryId(glossaryId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Glossary>(result.JsonObject);
        }

        /// <summary>
        /// Delete glossary. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteGlossary(long glossaryId)
        {
            string url = FormUrl_GlossaryId(glossaryId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Glossary {glossaryId} removal failed");
        }

        /// <summary>
        /// Edit glossary. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Glossary> EditGlossary(long glossaryId, IEnumerable<GlossaryPatch> patches)
        {
            string url = FormUrl_GlossaryId(glossaryId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Glossary>(result.JsonObject);
        }

        /// <summary>
        /// Concordance search in Glossaries. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.glossaries.concordance.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.glossaries.concordance.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<GlossaryConcordanceResultResource>> ConcordanceSearch(
            long projectId,
            ConcordanceSearchRequest request)
        {
            var url = $"/projects/{projectId}/glossaries/concordance";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseList<GlossaryConcordanceResultResource>(result.JsonObject);
        }

        #endregion

        #region Glossaries : Export

        /// <summary>
        /// Export glossary. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.exports.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.exports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GlossaryExportStatus> ExportGlossary(long glossaryId, ExportGlossaryRequest request)
        {
            var url = $"/glossaries/{glossaryId}/exports";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<GlossaryExportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Check glossary export status. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.exports.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.exports.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GlossaryExportStatus> CheckGlossaryExportStatus(long glossaryId, string exportId)
        {
            var url = $"/glossaries/{glossaryId}/exports/{exportId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<GlossaryExportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Download glossary. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.exports.download.download">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.exports.download.download">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadGlossary(long glossaryId, string exportId)
        {
            var url = $"/glossaries/{glossaryId}/exports/{exportId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        #endregion

        #region Glossaries : Import

        /// <summary>
        /// Import glossary. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.imports.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.imports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GlossaryImportStatus> ImportGlossary(long glossaryId, ImportGlossaryRequest request)
        {
            var url = $"/glossaries/{glossaryId}/imports";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<GlossaryImportStatus>(result.JsonObject);
        }

        /// <summary>
        /// Check glossary import status. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.imports.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.imports.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GlossaryImportStatus> CheckGlossaryImportStatus(long glossaryId, string importId)
        {
            var url = $"/glossaries/{glossaryId}/imports/{importId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<GlossaryImportStatus>(result.JsonObject);
        }

        #endregion

        #region Terms

        /// <summary>
        /// List terms. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.terms.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.terms.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<Term>> ListTerms(
            long glossaryId,
            long? userId = null,
            string? languageId = null,
            long? translationOfTermId = null,
            long? conceptId = null,
            string? croql = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null)
        {
            return ListTerms(glossaryId,
                new TermsListParams(limit, offset, userId, languageId, translationOfTermId, conceptId, croql, orderBy));
        }

        /// <summary>
        /// List terms. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.terms.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.terms.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Term>> ListTerms(long glossaryId, TermsListParams @params)
        {
            string url = FormUrl_Terms(glossaryId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<Term>(result.JsonObject);
        }

        /// <summary>
        /// Add term. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.terms.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.terms.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Term> AddTerm(long glossaryId, AddTermRequest request)
        {
            string url = FormUrl_Terms(glossaryId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Term>(result.JsonObject);
        }
        
        /// <summary>
        /// Clear glossary. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.terms.deleteMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.terms.deleteMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task ClearGlossary(
            long glossaryId,
            string? languageId = null,
            long? conceptId = null,
            long? translationOfTermId = null)
        {
            string url = FormUrl_Terms(glossaryId);

            var queryParams = new Dictionary<string, string>();
            queryParams.AddParamIfPresent("languageId", languageId);
            queryParams.AddParamIfPresent("conceptId", conceptId);
            queryParams.AddParamIfPresent("translationOfTermId", translationOfTermId);

            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url, queryParams);
            Utils.ThrowIfStatusNot204(statusCode, $"Glossary {glossaryId} cleanup failed");
        }

        /// <summary>
        /// Get term. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.terms.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.terms.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Term> GetTerm(long glossaryId, long termId)
        {
            string url = FormUrl_TermId(glossaryId, termId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Term>(result.JsonObject);
        }

        /// <summary>
        /// Delete term. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.terms.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.terms.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteTerm(long glossaryId, long termId)
        {
            string url = FormUrl_TermId(glossaryId, termId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Term {termId} removal failed");
        }

        /// <summary>
        /// Edit term. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.glossaries.terms.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.glossaries.terms.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Term> EditTerm(long glossaryId, long termId, IEnumerable<TermPatch> patches)
        {
            string url = FormUrl_TermId(glossaryId, termId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Term>(result.JsonObject);
        }

        #endregion
        
        #region Concepts
        
        /// <summary>
        /// List terms. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.glossaries.concepts.getMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.glossaries.concepts.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Concept>> ListConcepts(
            long glossaryId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null)
        {
            string url = FormUrl_Concepts(glossaryId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddSortingRulesIfPresent(orderBy);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Concept>(result.JsonObject);
        }
        
        /// <summary>
        /// List terms. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.glossaries.concepts.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.glossaries.concepts.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Concept> GetConcept(long glossaryId, long conceptId)
        {
            string url = FormUrl_ConceptId(glossaryId, conceptId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Concept>(result.JsonObject);
        }
        
        /// <summary>
        /// List terms. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.glossaries.concepts.put">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.glossaries.concepts.put">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Concept> UpdateConcept(long glossaryId, long conceptId, UpdateConceptRequest request)
        {
            string url = FormUrl_ConceptId(glossaryId, conceptId);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url, request);
            return _jsonParser.ParseResponseObject<Concept>(result.JsonObject);
        }
        
        /// <summary>
        /// List terms. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.glossaries.concepts.delete">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.glossaries.concepts.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteConcept(long glossaryId, long conceptId)
        {
            string url = FormUrl_ConceptId(glossaryId, conceptId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Concept {conceptId} removal failed");
        }
        
        #endregion

        #region Helper methods

        private static string FormUrl_GlossaryId(long glossaryId)
        {
            return $"{BaseUrl}/{glossaryId}";
        }

        private static string FormUrl_Terms(long glossaryId)
        {
            return $"{BaseUrl}/{glossaryId}/terms";
        }

        private static string FormUrl_TermId(long glossaryId, long termId)
        {
            return $"{BaseUrl}/{glossaryId}/terms/{termId}";
        }

        private static string FormUrl_Concepts(long glossaryId)
        {
            return $"{BaseUrl}/{glossaryId}/concepts";
        }

        private static string FormUrl_ConceptId(long glossaryId, long conceptId)
        {
            return $"{BaseUrl}/{glossaryId}/concepts/{conceptId}";
        }

        #endregion
    }
}