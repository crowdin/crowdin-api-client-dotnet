
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
            int projectId,
            string languageId,
            string? stringIds = null,
            string? labelIds = null,
            int? fileId = null,
            int? branchId = null,
            int? directoryId = null,
            string? croql = null,
            bool? denormalizePlaceholders = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<LanguageTranslations>> ListLanguageTranslations(
            int projectId,
            string languageId,
            LanguageTranslationsListParams @params);
        
        #region Approvals

        Task<ResponseList<TranslationApproval>> ListTranslationApprovals(
            int projectId,
            int? fileId = null,
            string? labelIds = null,
            string? excludeLabelIds = null,
            int? stringId = null,
            string? languageId = null,
            int? translationId = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<TranslationApproval>> ListTranslationApprovals(
            int projectId,
            TranslationApprovalsListParams @params);

        Task<TranslationApproval> AddApproval(int projectId, AddApprovalRequest request);

        Task<TranslationApproval> GetApproval(int projectId, int approvalId);

        Task RemoveApproval(int projectId, int approvalId);

        #endregion

        #region Translations

        Task<TranslationAlignment> TranslationAlignment(int projectId, TranslationAlignmentRequest request);

        Task<ResponseList<StringTranslation>> ListStringTranslations(
            int projectId,
            int stringId,
            string languageId,
            bool? denormalizePlaceholders = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<StringTranslation>> ListStringTranslations(
            int projectId,
            StringTranslationsListParams @params);

        Task<StringTranslation> AddTranslation(int projectId, AddTranslationRequest request);

        Task DeleteStringTranslations(int projectId, int stringId, string languageId);

        Task<StringTranslation> GetTranslation(int projectId, int translationId, bool? denormalizePlaceholders = null);

        Task<StringTranslation> RestoreTranslation(int projectId, int translationId);

        Task DeleteTranslation(int projectId, int translationId);

        #endregion

        #region Votes

        Task<ResponseList<TranslationVote>> ListTranslationVotes(
            int projectId,
            int? stringId = null,
            string? languageId = null,
            int? translationId = null,
            string? labelIds = null,
            string? excludeLabelIds = null,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<TranslationVote>> ListTranslationVotes(
            int projectId,
            TranslationVotesListParams @params);

        Task<TranslationVote> AddVote(int projectId, AddVoteRequest request);

        Task<TranslationVote> GetVote(int projectId, int voteId);

        Task CancelVote(int projectId, int voteId);

        #endregion
    }
}