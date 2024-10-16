
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Screenshots
{
    public class ScreenshotsApiExecutor
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
            int projectId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null,
            IEnumerable<int>? stringIds = null)
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
        public async Task<Screenshot> AddScreenshot(int projectId, AddScreenshotRequest request)
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
        public async Task<Screenshot> GetScreenshot(int projectId, int screenshotId)
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
        public async Task<Screenshot> UpdateScreenshot(int projectId, int screenshotId, UpdateScreenshotRequest request)
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
        public async Task DeleteScreenshot(int projectId, int screenshotId)
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
        public async Task<Screenshot> EditScreenshot(int projectId, int screenshotId, IEnumerable<ScreenshotPatch> patches)
        {
            string url = FormUrl_ScreenshotId(projectId, screenshotId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Screenshot>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Screenshots(int projectId)
        {
            return $"/projects/{projectId}/screenshots";
        }

        private static string FormUrl_ScreenshotId(int projectId, int screenshotId)
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
        public async Task<ResponseList<Tag>> ListTags(int projectId, int screenshotId, int limit = 25, int offset = 0)
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
        public async Task ReplaceTags(int projectId, int screenshotId, IEnumerable<AddTagRequest> request)
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
        public async Task ReplaceTags(int projectId, int screenshotId, AutoTagReplaceTagsRequest request)
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
        public async Task<ResponseList<Tag>> AddTag(int projectId, int screenshotId, IEnumerable<AddTagRequest> request)
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
        public async Task ClearTags(int projectId, int screenshotId)
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
        public async Task<Tag> GetTag(int projectId, int screenshotId, int tagId)
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
        public async Task DeleteTag(int projectId, int screenshotId, int tagId)
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
        public async Task<Screenshot> EditTag(int projectId, int screenshotId, int tagId, IEnumerable<TagPatch> patches)
        {
            string url = FormUrl_ScreenshotTagId(projectId, screenshotId, tagId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Screenshot>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_ScreenshotTags(int projectId, int screenshotId)
        {
            return FormUrl_ScreenshotId(projectId, screenshotId) + "/tags";
        }

        private static string FormUrl_ScreenshotTagId(int projectId, int screenshotId, int tagId)
        {
            return FormUrl_ScreenshotId(projectId, screenshotId) + $"/tags/{tagId}";
        }

        #endregion

        #endregion
    }
}