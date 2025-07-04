
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public interface IStringTranslationsApiExecutor
    {
        Task<ResponseList<LanguageTranslations>> ListLanguageTranslations(
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
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<LanguageTranslations>> ListLanguageTranslations(
            long projectId,
            string languageId,
            LanguageTranslationsListParams @params);
        
        #region Approvals

        Task<ResponseList<TranslationApproval>> ListTranslationApprovals(
            long projectId,
            long? fileId = null,
            string? labelIds = null,
            string? excludeLabelIds = null,
            long? stringId = null,
            string? languageId = null,
            long? translationId = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<TranslationApproval>> ListTranslationApprovals(
            long projectId,
            TranslationApprovalsListParams @params);

        Task<TranslationApproval> AddApproval(long projectId, AddApprovalRequest request);

        Task<TranslationApproval> GetApproval(long projectId, long approvalId);

        Task RemoveApproval(long projectId, long approvalId);

        Task RemoveStringApprovals(long projectId, long stringId);

        Task<ResponseList<TranslationApproval>> ApprovalBatchOperations(
            long projectId,
            IEnumerable<ApprovalBatchOpPatch> patches);

        #endregion

        #region Translations

        Task<TranslationAlignment> TranslationAlignment(long projectId, TranslationAlignmentRequest request);

        Task<ResponseList<StringTranslation>> ListStringTranslations(
            long projectId,
            long stringId,
            string languageId,
            bool? denormalizePlaceholders = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<StringTranslation>> ListStringTranslations(
            long projectId,
            StringTranslationsListParams @params);

        Task<StringTranslation> AddTranslation(long projectId, AddTranslationRequest request);

        Task DeleteStringTranslations(long projectId, long stringId, string? languageId = null);

        Task<ResponseList<StringTranslation>> TranslationBatchOperations(
            long projectId,
            IEnumerable<TranslationBatchOpPatch> patches);

        Task<StringTranslation> GetTranslation(long projectId, long translationId, bool? denormalizePlaceholders = null);

        Task<StringTranslation> RestoreTranslation(long projectId, long translationId);

        Task DeleteTranslation(long projectId, long translationId);

        #endregion

        #region Votes

        Task<ResponseList<TranslationVote>> ListTranslationVotes(
            long projectId,
            long? stringId = null,
            string? languageId = null,
            long? translationId = null,
            string? labelIds = null,
            string? excludeLabelIds = null,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<TranslationVote>> ListTranslationVotes(
            long projectId,
            TranslationVotesListParams @params);

        Task<TranslationVote> AddVote(long projectId, AddVoteRequest request);

        Task<TranslationVote> GetVote(long projectId, long voteId);

        Task CancelVote(long projectId, long voteId);

        #endregion
    }
}