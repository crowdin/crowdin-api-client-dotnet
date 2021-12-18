
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Translations
{
    public class TranslationsApiExecutor
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

        [PublicAPI]
        public async Task<PreTranslation> GetPreTranslationStatus(int projectId, int preTranslationId)
        {
            var url = $"/projects/{projectId}/pre-translations/{preTranslationId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<PreTranslation>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<PreTranslation> ApplyPreTranslation(int projectId, ApplyPreTranslationRequest request)
        {
            var url = $"/projects/{projectId}/pre-translations";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<PreTranslation>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<DirectoryBuild> BuildProjectDirectoryTranslation(
            int projectId, int directoryId,
            BuildProjectDirectoryTranslationRequest request)
        {
            var url = $"/projects/{projectId}/translations/builds/directories/{directoryId}";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<DirectoryBuild>(result.JsonObject);
        }

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

        [PublicAPI]
        public async Task<ResponseList<TranslationProjectBuild>> ListProjectBuilds(
            int projectId, int? branchId = null, int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("branchId", branchId);

            var url = $"/projects/{projectId}/translations/builds";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);

            return _jsonParser.ParseResponseList<TranslationProjectBuild>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<ProjectBuild> BuildProjectTranslation(int projectId, BuildProjectTranslationRequest request)
        {
            var url = $"/projects/{projectId}/translations/builds";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);

            return _jsonParser.ParseResponseObject<ProjectBuild>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<UploadTranslationsResponse> UploadTranslations(
            int projectId, int languageId, UploadTranslationsRequest request)
        {
            var url = $"/projects/{projectId}/translations/{languageId}";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);

            return _jsonParser.ParseResponseObject<UploadTranslationsResponse>(result.JsonObject);
        }

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

        [PublicAPI]
        public async Task<ProjectBuild> CheckProjectBuildStatus(int projectId, int buildId)
        {
            var url = $"/projects/{projectId}/translations/builds/{buildId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<ProjectBuild>(result.JsonObject);
        }

        [PublicAPI]
        public async Task CancelBuild(int projectId, int buildId)
        {
            var url = $"/projects/{projectId}/translations/builds/{buildId}";
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Build {buildId} cancellation failed");
        }

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