
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.StringTranslations
{
    public class StringTranslationsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;
        
        public StringTranslationsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public StringTranslationsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        #region Approvals

        [PublicAPI]
        public Task<ResponseList<TranslationApproval>> ListTranslationApprovals(
            int projectId,
            int? fileId = null, int? stringId = null,
            string? languageId = null, int? translationId = null,
            int limit = 25, int offset = 0)
        {
            return ListTranslationApprovals(projectId,
                new TranslationApprovalsListParams(fileId, stringId, languageId, translationId, limit, offset));
        }

        [PublicAPI]
        public async Task<ResponseList<TranslationApproval>> ListTranslationApprovals(
            int projectId, TranslationApprovalsListParams @params)
        {
            string url = FormUrl_Approvals(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<TranslationApproval>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<TranslationApproval> AddApproval(int projectId, AddApprovalRequest request)
        {
            string url = FormUrl_Approvals(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<TranslationApproval>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<TranslationApproval> GetApproval(int projectId, int approvalId)
        {
            string url = FormUrl_ApprovalId(projectId, approvalId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TranslationApproval>(result.JsonObject);
        }

        [PublicAPI]
        public async Task RemoveApproval(int projectId, int approvalId)
        {
            string url = FormUrl_ApprovalId(projectId, approvalId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Approval {approvalId} removal failed");
        }

        #region Helper methods

        private static string FormUrl_Approvals(int projectId)
        {
            return $"/projects/{projectId}/approvals";
        }

        private static string FormUrl_ApprovalId(int projectId, int approvalId)
        {
            return $"/projects/{projectId}/approvals/{approvalId}";
        }

        #endregion

        #endregion

        [PublicAPI]
        public Task<ResponseList<LanguageTranslations>> ListLanguageTranslations(
            int projectId, string languageId,
            string? stringIds = null, string? labelIds = null,
            int? fileId = null, string? croql = null, bool? denormalizePlaceholders = null,
            int limit = 25, int offset = 0)
        {
            return ListLanguageTranslations(projectId, languageId,
                new LanguageTranslationsListParams(stringIds, labelIds, 
                    fileId, croql, denormalizePlaceholders, limit, offset));
        }

        [PublicAPI]
        public async Task<ResponseList<LanguageTranslations>> ListLanguageTranslations(
            int projectId, string languageId, LanguageTranslationsListParams @params)
        {
            var url = $"/projects/{projectId}/languages/{languageId}/translations";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<LanguageTranslations>(result.JsonObject);
        }

        #region Translations

        [PublicAPI]
        public Task<ResponseList<StringTranslation>> ListStringTranslations(
            int projectId, int stringId, string languageId,
            bool? denormalizePlaceholders = null, int limit = 25, int offset = 0)
        {
            return ListStringTranslations(projectId,
                new StringTranslationsListParams(stringId, languageId, denormalizePlaceholders, limit, offset));
        }

        [PublicAPI]
        public async Task<ResponseList<StringTranslation>> ListStringTranslations(
            int projectId, StringTranslationsListParams @params)
        {
            string url = FormUrl_Translations(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<StringTranslation>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<StringTranslation> AddTranslation(int projectId, AddTranslationRequest request)
        {
            string url = FormUrl_Translations(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<StringTranslation>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteStringTranslations(int projectId, int stringId, string languageId)
        {
            string url = FormUrl_Translations(projectId);

            var queryParams = new Dictionary<string, string>
            {
                { "stringId", stringId.ToString() },
                { "languageId", languageId }
            };

            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url, queryParams);
            Utils.ThrowIfStatusNot204(statusCode, "String translation removal failed");
        }

        [PublicAPI]
        public async Task<StringTranslation> GetTranslation(int projectId, int translationId, bool? denormalizePlaceholders = null)
        {
            string url = FormUrl_TranslationId(projectId, translationId);
            
            IDictionary<string, string>? queryParams =
                denormalizePlaceholders.HasValue
                ? new Dictionary<string, string>
                {
                    { "denormalizePlaceholders", denormalizePlaceholders.Value ? "1" : "0" }
                }
                : null;

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseObject<StringTranslation>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<StringTranslation> RestoreTranslation(int projectId, int translationId)
        {
            string url = FormUrl_TranslationId(projectId, translationId);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url);
            return _jsonParser.ParseResponseObject<StringTranslation>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteTranslation(int projectId, int translationId)
        {
            string url = FormUrl_TranslationId(projectId, translationId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Translation {translationId} removal failed");
        }

        #region Helper methods

        private static string FormUrl_Translations(int projectId)
        {
            return $"/projects/{projectId}/translations";
        }

        private static string FormUrl_TranslationId(int projectId, int translationId)
        {
            return $"/projects/{projectId}/translations/{translationId}";
        }

        #endregion

        #endregion

        #region Votes

        [PublicAPI]
        public Task<ResponseList<TranslationVote>> ListTranslationVotes(
            int projectId, int? stringId = null, string? languageId = null,
            int? translationId = null, int limit = 25, int offset = 0)
        {
            return ListTranslationVotes(projectId,
                new TranslationVotesListParams(stringId, languageId, translationId, limit, offset));
        }

        [PublicAPI]
        public async Task<ResponseList<TranslationVote>> ListTranslationVotes(
            int projectId, TranslationVotesListParams @params)
        {
            string url = FormUrl_Votes(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<TranslationVote>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<TranslationVote> AddVote(int projectId, AddVoteRequest request)
        {
            string url = FormUrl_Votes(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<TranslationVote>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<TranslationVote> GetVote(int projectId, int voteId)
        {
            string url = FormUrl_VoteId(projectId, voteId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TranslationVote>(result.JsonObject);
        }

        [PublicAPI]
        public async Task CancelVote(int projectId, int voteId)
        {
            string url = FormUrl_VoteId(projectId, voteId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Vote {voteId} cancellation failed");
        }

        #region Helper methods

        private static string FormUrl_Votes(int projectId)
        {
            return $"/projects/{projectId}/votes";
        }

        private static string FormUrl_VoteId(int projectId, int voteId)
        {
            return $"/projects/{projectId}/votes/{voteId}";
        }

        #endregion

        #endregion
    }
}