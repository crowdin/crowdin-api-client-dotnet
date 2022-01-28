
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Users
{
    public class UsersApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public UsersApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public UsersApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List project members. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.members.getMany">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<TeamMember>> ListProjectMembers(
            int projectId, string? search = null, UserRole? role = null,
            string? languageId = null, int limit = 25, int offset = 0)
        {
            return ListProjectMembers(projectId,
                new ProjectMembersListParams(search, role, languageId, limit, offset));
        }
        
        /// <summary>
        /// List project members. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.members.getMany">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TeamMember>> ListProjectMembers(int projectId, ProjectMembersListParams @params)
        {
            string url = FormUrl_Members(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<TeamMember>(result.JsonObject);
        }

        /// <summary>
        /// List project members. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.members.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<ProjectMember>> ListProjectMembersEnterprise(
            int projectId, string? search = null, string? languageId = null,
            int? workflowStepId = null, int limit = 25, int offset = 0)
        {
            return ListProjectMembersEnterprise(projectId,
                new EnterpriseProjectMembersListParams(search, languageId, workflowStepId, limit, offset));
        }

        /// <summary>
        /// List project members. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.members.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<ProjectMember>> ListProjectMembersEnterprise(
            int projectId, EnterpriseProjectMembersListParams @params)
        {
            string url = FormUrl_Members(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<ProjectMember>(result.JsonObject);
        }

        /// <summary>
        /// Add project member. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.members.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ProjectMembersResponse> AddProjectMember(int projectId, AddProjectMemberRequest request)
        {
            string url = FormUrl_Members(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);

            return new ProjectMembersResponse
            {
                Skipped = _jsonParser.ParseArray<ProjectMember>(result.JsonObject["skipped"]!),
                Added = _jsonParser.ParseArray<ProjectMember>(result.JsonObject["added"]!),
                Pagination = _jsonParser.ParseResponseObject<Pagination>(result.JsonObject["pagination"]!)
            };
        }

        /// <summary>
        /// Get project member permissions. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.members.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ProjectMember> GetProjectMemberPermissions(int projectId, int memberId)
        {
            string url = FormUrl_MemberId(projectId, memberId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<ProjectMember>(result.JsonObject);
        }

        /// <summary>
        /// Replace project member permissions. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.members.put">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ProjectMember> ReplaceProjectMemberPermissions(
            int projectId, int memberId, ReplaceProjectMemberPermissionsRequest request)
        {
            string url = FormUrl_MemberId(projectId, memberId);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url, request);
            return _jsonParser.ParseResponseObject<ProjectMember>(result.JsonObject);
        }

        /// <summary>
        /// Delete member from project. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.members.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteMemberFromProject(int projectId, int memberId)
        {
            string url = FormUrl_MemberId(projectId, memberId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Project member {memberId} removal failed");
        }

        /// <summary>
        /// List users. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.users.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<UserEnterprise>> ListUsers(
            UserStatus? status = null, string? search = null,
            UserTwoFactorStatus? twoFactor = null, int limit = 25, int offset = 0)
        {
            return ListUsers(new EnterpriseUsersListParams(status, search, twoFactor, limit, offset));
        }

        /// <summary>
        /// List users. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.users.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<UserEnterprise>> ListUsers(EnterpriseUsersListParams @params)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest("/users", @params.ToQueryParams());
            return _jsonParser.ParseResponseList<UserEnterprise>(result.JsonObject);
        }

        /// <summary>
        /// Get user. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.users.getById">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<UserEnterprise> GetUser(int userId)
        {
            var url = $"/users/{userId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<UserEnterprise>(result.JsonObject);
        }

        /// <summary>
        /// Get authenticated user. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.user.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.user.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<T> GetAuthenticatedUser<T>()
            where T : UserBase // User, UserEnterprise
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest("/user");
            return _jsonParser.ParseResponseObject<T>(result.JsonObject);
        }
        
        /// <summary>
        /// Get member info. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.members.get">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TeamMember> GetMemberInfo(int projectId, int memberId)
        {
            string url = FormUrl_MemberId(projectId, memberId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TeamMember>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Members(int projectId)
        {
            return $"/projects/{projectId}/members";
        }
        
        private static string FormUrl_MemberId(int projectId, int memberId)
        {
            return $"/projects/{projectId}/members/{memberId}";
        }

        #endregion
    }
}