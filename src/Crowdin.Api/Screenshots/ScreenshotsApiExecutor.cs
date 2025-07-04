
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Screenshots
{
    public class ScreenshotsApiExecutor : IScreenshotsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public ScreenshotsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public ScreenshotsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        #region Screenshots

        /// <summary>
        /// List screenshots. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Screenshot>> ListScreenshots(
            long projectId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null,
            IEnumerable<long>? stringIds = null)
        {
            string url = FormUrl_Screenshots(projectId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddSortingRulesIfPresent(orderBy);
            queryParams.AddParamIfPresent("stringIds", stringIds);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Screenshot>(result.JsonObject);
        }

        /// <summary>
        /// Add screenshot. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Screenshot> AddScreenshot(long projectId, AddScreenshotRequest request)
        {
            string url = FormUrl_Screenshots(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Screenshot>(result.JsonObject);
        }

        /// <summary>
        /// Get screenshot. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Screenshot> GetScreenshot(long projectId, long screenshotId)
        {
            string url = FormUrl_ScreenshotId(projectId, screenshotId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Screenshot>(result.JsonObject);
        }

        /// <summary>
        /// Update screenshot. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.put">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.put">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Screenshot> UpdateScreenshot(long projectId, long screenshotId, UpdateScreenshotRequest request)
        {
            string url = FormUrl_ScreenshotId(projectId, screenshotId);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url, request);
            return _jsonParser.ParseResponseObject<Screenshot>(result.JsonObject);
        }

        /// <summary>
        /// Delete screenshot. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteScreenshot(long projectId, long screenshotId)
        {
            string url = FormUrl_ScreenshotId(projectId, screenshotId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Screenshot {screenshotId} removal failed");
        }

        /// <summary>
        /// Edit screenshot. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Screenshot> EditScreenshot(long projectId, long screenshotId, IEnumerable<ScreenshotPatch> patches)
        {
            string url = FormUrl_ScreenshotId(projectId, screenshotId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Screenshot>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Screenshots(long projectId)
        {
            return $"/projects/{projectId}/screenshots";
        }

        private static string FormUrl_ScreenshotId(long projectId, long screenshotId)
        {
            return $"/projects/{projectId}/screenshots/{screenshotId}";
        }

        #endregion

        #endregion

        #region Tags

        /// <summary>
        /// List tags. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.tags.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.tags.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Tag>> ListTags(long projectId, long screenshotId, int limit = 25, int offset = 0)
        {
            string url = FormUrl_ScreenshotId(projectId, screenshotId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Tag>(result.JsonObject);
        }

        /// <summary>
        /// Replace tags. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.tags.putMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.tags.putMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task ReplaceTags(long projectId, long screenshotId, IEnumerable<AddTagRequest> request)
        {
            string url = FormUrl_ScreenshotTags(projectId, screenshotId);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url, request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new CrowdinApiException($"Failed to replace tags of screenshot {screenshotId}");
            }
        }

        /// <summary>
        /// Replace tags. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.tags.putMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.tags.putMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task ReplaceTags(long projectId, long screenshotId, AutoTagReplaceTagsRequest request)
        {
            string url = FormUrl_ScreenshotTags(projectId, screenshotId);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url, request);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new CrowdinApiException($"Failed to set AutoTag flag for screenshot {screenshotId}");
            }
        }

        /// <summary>
        /// Add tag. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.tags.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.tags.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Tag>> AddTag(long projectId, long screenshotId, IEnumerable<AddTagRequest> request)
        {
            string url = FormUrl_ScreenshotTags(projectId, screenshotId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseList<Tag>(result.JsonObject);
        }

        /// <summary>
        /// Clear tags. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.tags.deleteMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.tags.deleteMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task ClearTags(long projectId, long screenshotId)
        {
            string url = FormUrl_ScreenshotTags(projectId, screenshotId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Tags cleanup failed");
        }

        /// <summary>
        /// Get tag. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.tags.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.tags.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Tag> GetTag(long projectId, long screenshotId, long tagId)
        {
            string url = FormUrl_ScreenshotTagId(projectId, screenshotId, tagId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Tag>(result.JsonObject);
        }

        /// <summary>
        /// Delete tag. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.tags.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.tags.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteTag(long projectId, long screenshotId, long tagId)
        {
            string url = FormUrl_ScreenshotTagId(projectId, screenshotId, tagId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Tag {tagId} removal failed");
        }

        /// <summary>
        /// Edit tag. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.screenshots.tags.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.screenshots.tags.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Screenshot> EditTag(long projectId, long screenshotId, long tagId, IEnumerable<TagPatch> patches)
        {
            string url = FormUrl_ScreenshotTagId(projectId, screenshotId, tagId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Screenshot>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_ScreenshotTags(long projectId, long screenshotId)
        {
            return FormUrl_ScreenshotId(projectId, screenshotId) + "/tags";
        }

        private static string FormUrl_ScreenshotTagId(long projectId, long screenshotId, long tagId)
        {
            return FormUrl_ScreenshotId(projectId, screenshotId) + $"/tags/{tagId}";
        }

        #endregion

        #endregion
    }
}