
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public interface ITranslationStatusApiExecutor
    {
        Task<ResponseList<ProgressResource>> GetBranchProgress(
            long projectId,
            long branchId,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<ProgressResource>> GetDirectoryProgress(
            long projectId,
            long directoryId,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<FileProgressResource>> GetFileProgress(
            long projectId,
            long fileId,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<LanguageProgressResource>> GetLanguageProgress(
            long projectId,
            string languageId,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<ProgressResource>> GetProjectProgress(
            long projectId,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<QaCheckResource>> ListQaCheckIssues(
            long projectId,
            int limit = 25,
            int offset = 0,
            ICollection<QaCheckIssueCategory>? categories = null,
            ICollection<QaCheckIssueValidationType>? validation = null,
            ICollection<string>? languageIds = null);

        Task<ResponseList<QaCheckResource>> ListQaCheckIssues(long projectId, QaCheckIssuesListParams @params);
    }
}