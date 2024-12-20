
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
            int projectId,
            int branchId,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<ProgressResource>> GetDirectoryProgress(
            int projectId,
            int directoryId,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<FileProgressResource>> GetFileProgress(
            int projectId,
            int fileId,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<LanguageProgressResource>> GetLanguageProgress(
            int projectId,
            string languageId,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<ProgressResource>> GetProjectProgress(
            int projectId,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<QaCheckResource>> ListQaCheckIssues(
            int projectId,
            int limit = 25,
            int offset = 0,
            ICollection<QaCheckIssueCategory>? categories = null,
            ICollection<QaCheckIssueValidationType>? validation = null,
            ICollection<string>? languageIds = null);

        Task<ResponseList<QaCheckResource>> ListQaCheckIssues(int projectId, QaCheckIssuesListParams @params);
    }
}