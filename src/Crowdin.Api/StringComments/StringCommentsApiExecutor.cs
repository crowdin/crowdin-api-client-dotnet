
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.StringComments
{
    public class StringCommentsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public StringCommentsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public StringCommentsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        [PublicAPI]
        public Task ListStringComments(
            int projectId, int limit = 25, int offset = 0,
            int? stringId = null, StringCommentType? type = null,
            ISet<IssueType>? issueTypes = null, IssueStatus? issueStatus = null)
        {
            return ListStringComments(projectId,
                new StringCommentsListParams(limit, offset, stringId, type, issueTypes, issueStatus));
        }

        [PublicAPI]
        public async Task<ResponseList<StringComment>> ListStringComments(
            int projectId, StringCommentsListParams @params)
        {
            string url = FormUrl_Comments(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<StringComment>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<StringComment> AddStringComment(int projectId, AddStringCommentRequest request)
        {
            string url = FormUrl_Comments(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<StringComment>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<StringComment> GetStringComment(int projectId, int stringCommentId)
        {
            string url = FormUrl_CommentId(projectId, stringCommentId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<StringComment>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteStringComment(int projectId, int stringCommentId)
        {
            string url = FormUrl_CommentId(projectId, stringCommentId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"String Comment {stringCommentId} removal failed");
        }

        [PublicAPI]
        public async Task<StringComment> EditStringComment(
            int projectId, int stringCommentId, IEnumerable<StringCommentPatch> patches)
        {
            string url = FormUrl_CommentId(projectId, stringCommentId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<StringComment>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Comments(int projectId)
        {
            return $"/projects/{projectId}/comments";
        }

        private static string FormUrl_CommentId(int projectId, int stringCommentId)
        {
            return $"/projects/{projectId}/comments/{stringCommentId}";
        }

        #endregion
    }
}