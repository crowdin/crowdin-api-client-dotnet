
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Translations
{
    public class TranslationsApiExecutor : ITranslationsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public TranslationsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public TranslationsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List Pre-Translations. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Translations/operation/api.projects.pre-translations.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Translations/operation/api.projects.pre-translations.getMany">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Translations/operation/api.projects.pre-translations.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<PreTranslation>> ListPreTranslations(
            int projectId,
            int limit = 25,
            int offset = 0)
        {
            var url = $"/projects/{projectId}/pre-translations";
            
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<PreTranslation>(result.JsonObject);
        }

        /// <summary>
        /// Edit Pre-Translation. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Translations/operation/api.projects.pre-translations.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Translations/operation/api.projects.pre-translations.patch">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Translations/operation/api.projects.pre-translations.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<PreTranslation> EditPreTranslation(
            int projectId,
            string preTranslationId,
            IEnumerable<PreTranslationPatch> patches)
        {
            var url = $"/projects/{projectId}/pre-translations/{preTranslationId}";
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<PreTranslation>(result.JsonObject);
        }

        /// <summary>
        /// Pre-Translation Report. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Translations/operation/api.projects.pre-translations.report.getReport">Crowdin API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/Translations/operation/api.projects.pre-translations.report.getReport">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Translations/operation/api.projects.pre-translations.report.getReport">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<PreTranslationReport> PreTranslationReport(int projectId, string preTranslationId)
        {
            var url = $"/projects/{projectId}/pre-translations/{preTranslationId}/report";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<PreTranslationReport>(result.JsonObject);
        }

        /// <summary>
        /// Get pre-translation status. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#tag/Translations/paths/~1projects~1{projectId}~1pre-translations~1{preTranslationId}/get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#tag/Translations/paths/~1projects~1{projectId}~1pre-translations~1{preTranslationId}/get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<PreTranslation> GetPreTranslationStatus(int projectId, string preTranslationId)
        {
            var url = $"/projects/{projectId}/pre-translations/{preTranslationId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<PreTranslation>(result.JsonObject);
        }

        /// <summary>
        /// Apply pre-translation. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.pre-translations.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.pre-translations.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<PreTranslation> ApplyPreTranslation(int projectId, ApplyPreTranslationRequest request)
        {
            var url = $"/projects/{projectId}/pre-translations";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<PreTranslation>(result.JsonObject);
        }

        /// <summary>
        /// Build project directory translation. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.builds.directories.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.builds.directories.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DirectoryBuild> BuildProjectDirectoryTranslation(
            int projectId,
            int directoryId,
            BuildProjectDirectoryTranslationRequest request)
        {
            var url = $"/projects/{projectId}/translations/builds/directories/{directoryId}";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<DirectoryBuild>(result.JsonObject);
        }

        /// <summary>
        /// Build project file translation. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.builds.files.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.builds.files.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<BuildProjectFileTranslationResponse> BuildProjectFileTranslation(
            int projectId, int fileId,
            BuildProjectFileTranslationRequest request,
            string? etag = null)
        {
            var headers = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(etag))
            {
                headers.Add("If-None-Match", etag!);
            }

            var url = $"/projects/{projectId}/translations/builds/files/{fileId}";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request, headers);

            switch (result.StatusCode)
            {
                case HttpStatusCode.NoContent:
                {
                    return new BuildProjectFileTranslationResponse(
                        BuildProjectFileTranslationResponse.ResponseType.NoContent);
                }

                case HttpStatusCode.NotModified:
                {
                    return new BuildProjectFileTranslationResponse(
                        BuildProjectFileTranslationResponse.ResponseType.FileNotModified);
                }

                default:
                {
                    return new BuildProjectFileTranslationResponse(
                        _jsonParser.ParseResponseObject<FileDownloadLink>(result.JsonObject));
                }
            }
        }

        /// <summary>
        /// List project builds. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.builds.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.builds.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TranslationProjectBuild>> ListProjectBuilds(
            int projectId,
            int? branchId = null,
            int limit = 25,
            int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("branchId", branchId);

            var url = $"/projects/{projectId}/translations/builds";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);

            return _jsonParser.ParseResponseList<TranslationProjectBuild>(result.JsonObject);
        }

        /// <summary>
        /// Build project translation. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.builds.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.builds.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ProjectBuild> BuildProjectTranslation(int projectId, BuildProjectTranslationRequest request)
        {
            var url = $"/projects/{projectId}/translations/builds";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);

            return _jsonParser.ParseResponseObject<ProjectBuild>(result.JsonObject);
        }

        /// <summary>
        /// Upload translations. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.postOnLanguage">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.postOnLanguage">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<UploadTranslationsResponse> UploadTranslations(
            int projectId,
            string languageId,
            UploadTranslationsRequest request)
        {
            var url = $"/projects/{projectId}/translations/{languageId}";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);

            return _jsonParser.ParseResponseObject<UploadTranslationsResponse>(result.JsonObject);
        }

        /// <summary>
        /// Download project translations. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.builds.download.download">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.builds.download.download">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadProjectTranslationsResponse> DownloadProjectTranslations(int projectId, int buildId)
        {
            var url = $"/projects/{projectId}/translations/builds/{buildId}/download";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);

            return result.StatusCode is HttpStatusCode.Accepted
                // 202
                ? new DownloadProjectTranslationsResponse(
                    _jsonParser.ParseResponseObject<ProjectBuild>(result.JsonObject))
                // 200
                : new DownloadProjectTranslationsResponse(
                    _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject));
        }

        /// <summary>
        /// Check project build status. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.builds.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.builds.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ProjectBuild> CheckProjectBuildStatus(int projectId, int buildId)
        {
            var url = $"/projects/{projectId}/translations/builds/{buildId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<ProjectBuild>(result.JsonObject);
        }

        /// <summary>
        /// Cancel build. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.builds.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.builds.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task CancelBuild(int projectId, int buildId)
        {
            var url = $"/projects/{projectId}/translations/builds/{buildId}";
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Build {buildId} cancellation failed");
        }

        /// <summary>
        /// Export project translation. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.translations.exports.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.translations.exports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink?> ExportProjectTranslation(int projectId, ExportProjectTranslationRequest request)
        {
            var url = $"/projects/{projectId}/translations/exports";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);

            if (result.StatusCode is HttpStatusCode.NoContent) return null;
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }
    }
}