
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

        [PublicAPI]
        public Task<ResponseList<TeamMember>> ListProjectMembers(
            int projectId, string? search = null, UserRole? role = null,
            string? languageId = null, int limit = 25, int offset = 0)
        {
            return ListProjectMembers(projectId,
                new ProjectMembersListParams(search, role, languageId, limit, offset));
        }
        
        [PublicAPI]
        public async Task<ResponseList<TeamMember>> ListProjectMembers(int projectId, ProjectMembersListParams @params)
        {
            string url = FormUrl_Members(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<TeamMember>(result.JsonObject);
        }

        [PublicAPI]
        public Task<ResponseList<ProjectMember>> ListProjectMembersEnterprise(
            int projectId, string? search = null, string? languageId = null,
            int? workflowStepId = null, int limit = 25, int offset = 0)
        {
            return ListProjectMembersEnterprise(projectId,
                new EnterpriseProjectMembersListParams(search, languageId, workflowStepId, limit, offset));
        }

        [PublicAPI]
        public async Task<ResponseList<ProjectMember>> ListProjectMembersEnterprise(
            int projectId, EnterpriseProjectMembersListParams @params)
        {
            string url = FormUrl_Members(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<ProjectMember>(result.JsonObject);
        }

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

        [PublicAPI]
        public async Task<ProjectMember> GetProjectMemberPermissions(int projectId, int memberId)
        {
            string url = FormUrl_MemberId(projectId, memberId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<ProjectMember>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<ProjectMember> ReplaceProjectMemberPermissions(
            int projectId, int memberId, ReplaceProjectMemberPermissionsRequest request)
        {
            string url = FormUrl_MemberId(projectId, memberId);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url, request);
            return _jsonParser.ParseResponseObject<ProjectMember>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteMemberFromProject(int projectId, int memberId)
        {
            string url = FormUrl_MemberId(projectId, memberId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Project member {memberId} removal failed");
        }

        [PublicAPI]
        public Task<ResponseList<UserEnterprise>> ListUsers(
            UserStatus? status = null, string? search = null,
            UserTwoFactorStatus? twoFactor = null, int limit = 25, int offset = 0)
        {
            return ListUsers(new EnterpriseUsersListParams(status, search, twoFactor, limit, offset));
        }

        [PublicAPI]
        public async Task<ResponseList<UserEnterprise>> ListUsers(EnterpriseUsersListParams @params)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest("/users", @params.ToQueryParams());
            return _jsonParser.ParseResponseList<UserEnterprise>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<UserEnterprise> GetUser(int userId)
        {
            var url = $"/users/{userId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<UserEnterprise>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<T> GetAuthenticatedUser<T>()
            where T : UserBase // User, UserEnterprise
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest("/user");
            return _jsonParser.ParseResponseObject<T>(result.JsonObject);
        }
        
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