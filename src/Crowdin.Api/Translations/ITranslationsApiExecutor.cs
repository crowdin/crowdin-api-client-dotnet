
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public interface ITranslationsApiExecutor
    {
        Task<ResponseList<PreTranslation>> ListPreTranslations(
            long projectId,
            int limit = 25,
            int offset = 0);

        Task<PreTranslation> EditPreTranslation(
            long projectId,
            string preTranslationId,
            IEnumerable<PreTranslationPatch> patches);

        Task<PreTranslation> GetPreTranslationStatus(long projectId, string preTranslationId);

        Task<PreTranslation> ApplyPreTranslation(long projectId, ApplyPreTranslationRequest request);

        Task<DirectoryBuild> BuildProjectDirectoryTranslation(
            long projectId,
            long directoryId,
            BuildProjectDirectoryTranslationRequest request);

        Task<BuildProjectFileTranslationResponse> BuildProjectFileTranslation(
            long projectId, long fileId,
            BuildProjectFileTranslationRequest request,
            string? etag = null);

        Task<ResponseList<TranslationProjectBuild>> ListProjectBuilds(
            long projectId,
            long? branchId = null,
            int limit = 25,
            int offset = 0);

        Task<ProjectBuild> BuildProjectTranslation(long projectId, BuildProjectTranslationRequest request);

        Task<UploadTranslationsResponse> UploadTranslations(
            long projectId,
            string languageId,
            UploadTranslationsRequest request);

        Task<DownloadProjectTranslationsResponse> DownloadProjectTranslations(long projectId, long buildId);

        Task<ProjectBuild> CheckProjectBuildStatus(long projectId, long buildId);

        Task CancelBuild(long projectId, long buildId);

        Task<DownloadLink?> ExportProjectTranslation(long projectId, ExportProjectTranslationRequest request);
    }
}