
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
            int projectId,
            int limit = 25,
            int offset = 0);

        Task<PreTranslation> EditPreTranslation(
            int projectId,
            string preTranslationId,
            IEnumerable<PreTranslationPatch> patches);

        Task<PreTranslation> GetPreTranslationStatus(int projectId, string preTranslationId);

        Task<PreTranslation> ApplyPreTranslation(int projectId, ApplyPreTranslationRequest request);

        Task<DirectoryBuild> BuildProjectDirectoryTranslation(
            int projectId,
            int directoryId,
            BuildProjectDirectoryTranslationRequest request);

        Task<BuildProjectFileTranslationResponse> BuildProjectFileTranslation(
            int projectId, int fileId,
            BuildProjectFileTranslationRequest request,
            string? etag = null);

        Task<ResponseList<TranslationProjectBuild>> ListProjectBuilds(
            int projectId,
            int? branchId = null,
            int limit = 25,
            int offset = 0);

        Task<ProjectBuild> BuildProjectTranslation(int projectId, BuildProjectTranslationRequest request);

        Task<UploadTranslationsResponse> UploadTranslations(
            int projectId,
            string languageId,
            UploadTranslationsRequest request);

        Task<DownloadProjectTranslationsResponse> DownloadProjectTranslations(int projectId, int buildId);

        Task<ProjectBuild> CheckProjectBuildStatus(int projectId, int buildId);

        Task CancelBuild(int projectId, int buildId);

        Task<DownloadLink?> ExportProjectTranslation(int projectId, ExportProjectTranslationRequest request);
    }
}