
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.StringComments
{
    public class StringCommentsApiExecutor : IStringCommentsApiExecutor
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

        /// <summary>
        /// List string comments. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.comments.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.comments.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task ListStringComments(
            int projectId,
            int limit = 25,
            int offset = 0,
            int? stringId = null,
            StringCommentType? type = null,
            ISet<IssueType>? issueTypes = null,
            IssueStatus? issueStatus = null,
            IEnumerable<SortingRule>? orderBy = null)
        {
            return ListStringComments(projectId,
                new StringCommentsListParams(limit, offset, stringId, type, issueTypes, issueStatus, orderBy));
        }

        /// <summary>
        /// List string comments. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.comments.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.comments.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<StringComment>> ListStringComments(
            int projectId,
            StringCommentsListParams @params)
        {
            string url = FormUrl_Comments(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<StringComment>(result.JsonObject);
        }

        /// <summary>
        /// Add string comment. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.comments.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.comments.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StringComment> AddStringComment(int projectId, AddStringCommentRequest request)
        {
            string url = FormUrl_Comments(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<StringComment>(result.JsonObject);
        }

        /// <summary>
        /// Get string comment. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.comments.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.comments.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StringComment> GetStringComment(int projectId, int stringCommentId)
        {
            string url = FormUrl_CommentId(projectId, stringCommentId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<StringComment>(result.JsonObject);
        }

        /// <summary>
        /// Delete string comment. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.comments.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.comments.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteStringComment(int projectId, int stringCommentId)
        {
            string url = FormUrl_CommentId(projectId, stringCommentId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"String Comment {stringCommentId} removal failed");
        }

        /// <summary>
        /// Edit string comment. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.comments.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.comments.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StringComment> EditStringComment(
            int projectId,
            int stringCommentId,
            IEnumerable<StringCommentPatch> patches)
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