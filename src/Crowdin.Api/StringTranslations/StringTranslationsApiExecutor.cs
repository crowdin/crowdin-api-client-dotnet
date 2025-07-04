
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.StringTranslations
{
    public class StringTranslationsApiExecutor : IStringTranslationsApiExecutor
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

        /// <summary>
        /// List translation approvals. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.approvals.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.approvals.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<TranslationApproval>> ListTranslationApprovals(
            long projectId,
            long? fileId = null, 
            string? labelIds = null,
            string? excludeLabelIds = null,
            long? stringId = null,
            string? languageId = null,
            long? translationId = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null)
        {
            return ListTranslationApprovals(projectId,
                new TranslationApprovalsListParams(fileId, labelIds,
                    excludeLabelIds, stringId, languageId, translationId, limit, offset, orderBy));
        }

        /// <summary>
        /// List translation approvals. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.approvals.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.approvals.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TranslationApproval>> ListTranslationApprovals(
            long projectId,
            TranslationApprovalsListParams @params)
        {
            string url = FormUrl_Approvals(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<TranslationApproval>(result.JsonObject);
        }

        /// <summary>
        /// Add approval. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.approvals.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.approvals.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TranslationApproval> AddApproval(long projectId, AddApprovalRequest request)
        {
            string url = FormUrl_Approvals(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<TranslationApproval>(result.JsonObject);
        }

        /// <summary>
        /// Get approval. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.approvals.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.approvals.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TranslationApproval> GetApproval(long projectId, long approvalId)
        {
            string url = FormUrl_ApprovalId(projectId, approvalId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TranslationApproval>(result.JsonObject);
        }

        /// <summary>
        /// Remove approval. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.approvals.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.approvals.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task RemoveApproval(long projectId, long approvalId)
        {
            string url = FormUrl_ApprovalId(projectId, approvalId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Approval {approvalId} removal failed");
        }

        /// <summary>
        /// Remove string approvals. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/String-Translations/operation/api.projects.approvals.deleteMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/String-Translations/operation/api.projects.approvals.deleteMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task RemoveStringApprovals(long projectId, long stringId)
        {
            string url = FormUrl_Approvals(projectId);

            var queryParams = new Dictionary<string, string>(1)
            {
                ["stringId"] = stringId.ToString()
            };
            
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url, queryParams);
            Utils.ThrowIfStatusNot204(statusCode, $"Approvals for string {stringId} removal failed");
        }

        /// <summary>
        /// Approval Batch Operations. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/String-Translations/operation/api.projects.approvals.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/String-Translations/operation/api.projects.approvals.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TranslationApproval>> ApprovalBatchOperations(
            long projectId,
            IEnumerable<ApprovalBatchOpPatch> patches)
        {
            string url = FormUrl_Approvals(projectId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseList<TranslationApproval>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Approvals(long projectId)
        {
            return $"/projects/{projectId}/approvals";
        }

        private static string FormUrl_ApprovalId(long projectId, long approvalId)
        {
            return $"/projects/{projectId}/approvals/{approvalId}";
        }

        #endregion

        #endregion

        /// <summary>
        /// List language translations. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.languages.translations.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.languages.translations.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<LanguageTranslations>> ListLanguageTranslations(
            long projectId,
            string languageId,
            string? stringIds = null,
            string? labelIds = null,
            long? fileId = null,
            long? branchId = null,
            long? directoryId = null,
            string? croql = null,
            bool? denormalizePlaceholders = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null)
        {
            return ListLanguageTranslations(projectId, languageId,
                new LanguageTranslationsListParams(stringIds, labelIds, 
                    fileId, branchId, directoryId, croql, denormalizePlaceholders, limit, offset, orderBy));
        }

        /// <summary>
        /// List language translations. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.languages.translations.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.languages.translations.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<LanguageTranslations>> ListLanguageTranslations(
            long projectId, string languageId, LanguageTranslationsListParams @params)
        {
            var url = $"/projects/{projectId}/languages/{languageId}/translations";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<LanguageTranslations>(result.JsonObject);
        }

        #region Translations

        /// <summary>
        /// Translation Alignment. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.translations.alignment.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.translations.alignment.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TranslationAlignment> TranslationAlignment(long projectId, TranslationAlignmentRequest request)
        {
            var url = $"/projects/{projectId}/translations/alignment";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<TranslationAlignment>(result.JsonObject);
        }

        /// <summary>
        /// List string translations. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<StringTranslation>> ListStringTranslations(
            long projectId,
            long stringId,
            string languageId,
            bool? denormalizePlaceholders = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null)
        {
            return ListStringTranslations(projectId,
                new StringTranslationsListParams(stringId, languageId,
                    denormalizePlaceholders, limit, offset, orderBy));
        }

        /// <summary>
        /// List string translations. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<StringTranslation>> ListStringTranslations(
            long projectId,
            StringTranslationsListParams @params)
        {
            string url = FormUrl_Translations(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<StringTranslation>(result.JsonObject);
        }

        /// <summary>
        /// Add translation. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StringTranslation> AddTranslation(long projectId, AddTranslationRequest request)
        {
            string url = FormUrl_Translations(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<StringTranslation>(result.JsonObject);
        }

        /// <summary>
        /// Delete string translations. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.deleteMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.deleteMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteStringTranslations(long projectId, long stringId, string? languageId = null)
        {
            string url = FormUrl_Translations(projectId);

            var queryParams = new Dictionary<string, string>
            {
                ["stringId"] = stringId.ToString(),
            };

            if (!string.IsNullOrWhiteSpace(languageId))
            {
                queryParams.Add("languageId", languageId!);
            }

            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url, queryParams);
            Utils.ThrowIfStatusNot204(statusCode, "String translation removal failed");
        }

        /// <summary>
        /// Translation Batch Operations. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/String-Translations/operation/api.projects.translations.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/String-Translations/operation/api.projects.translations.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<StringTranslation>> TranslationBatchOperations(
            long projectId,
            IEnumerable<TranslationBatchOpPatch> patches)
        {
            string url = FormUrl_Translations(projectId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseList<StringTranslation>(result.JsonObject);
        }

        /// <summary>
        /// Get translation. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StringTranslation> GetTranslation(long projectId, long translationId, bool? denormalizePlaceholders = null)
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

        /// <summary>
        /// Restore translation. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.put">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.put">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StringTranslation> RestoreTranslation(long projectId, long translationId)
        {
            string url = FormUrl_TranslationId(projectId, translationId);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url);
            return _jsonParser.ParseResponseObject<StringTranslation>(result.JsonObject);
        }

        /// <summary>
        /// Delete translation. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteTranslation(long projectId, long translationId)
        {
            string url = FormUrl_TranslationId(projectId, translationId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Translation {translationId} removal failed");
        }

        #region Helper methods

        private static string FormUrl_Translations(long projectId)
        {
            return $"/projects/{projectId}/translations";
        }

        private static string FormUrl_TranslationId(long projectId, long translationId)
        {
            return $"/projects/{projectId}/translations/{translationId}";
        }

        #endregion

        #endregion

        #region Votes

        /// <summary>
        /// List translation votes. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.votes.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.votes.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<TranslationVote>> ListTranslationVotes(
            long projectId,
            long? stringId = null,
            string? languageId = null,
            long? translationId = null, 
            string? labelIds = null,
            string? excludeLabelIds = null,
            int limit = 25,
            int offset = 0)
        {
            return ListTranslationVotes(projectId,
                new TranslationVotesListParams(stringId, languageId, translationId, labelIds, excludeLabelIds , limit, offset));
        }

        /// <summary>
        /// List translation votes. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.votes.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.votes.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TranslationVote>> ListTranslationVotes(
            long projectId,
            TranslationVotesListParams @params)
        {
            string url = FormUrl_Votes(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<TranslationVote>(result.JsonObject);
        }

        /// <summary>
        /// Add vote. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.votes.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.votes.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TranslationVote> AddVote(long projectId, AddVoteRequest request)
        {
            string url = FormUrl_Votes(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<TranslationVote>(result.JsonObject);
        }

        /// <summary>
        /// Get vote. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.votes.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.votes.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TranslationVote> GetVote(long projectId, long voteId)
        {
            string url = FormUrl_VoteId(projectId, voteId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TranslationVote>(result.JsonObject);
        }

        /// <summary>
        /// Cancel vote. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.votes.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.votes.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task CancelVote(long projectId, long voteId)
        {
            string url = FormUrl_VoteId(projectId, voteId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Vote {voteId} cancellation failed");
        }

        #region Helper methods

        private static string FormUrl_Votes(long projectId)
        {
            return $"/projects/{projectId}/votes";
        }

        private static string FormUrl_VoteId(long projectId, long voteId)
        {
            return $"/projects/{projectId}/votes/{voteId}";
        }

        #endregion

        #endregion
    }
}