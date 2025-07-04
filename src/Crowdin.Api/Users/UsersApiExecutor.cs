
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;
using Crowdin.Api.ProjectsGroups;

#nullable enable

namespace Crowdin.Api.Users
{
    public class UsersApiExecutor : IUsersApiExecutor
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
            long projectId,
            string? search = null,
            UserRole? role = null,
            string? languageId = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null)
        {
            return ListProjectMembers(projectId,
                new ProjectMembersListParams(search, role, languageId, limit, offset, orderBy));
        }
        
        /// <summary>
        /// List project members. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.members.getMany">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TeamMember>> ListProjectMembers(long projectId, ProjectMembersListParams @params)
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
            long projectId,
            string? search = null,
            string? languageId = null,
            long? workflowStepId = null,
            int limit = 25,
            int offset = 0)
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
            long projectId,
            EnterpriseProjectMembersListParams @params)
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
        public async Task<ProjectMembersResponse> AddProjectMember(long projectId, AddProjectMemberRequest request)
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
        public async Task<ProjectMember> GetProjectMemberPermissions(long projectId, long memberId)
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
            long projectId,
            long memberId,
            ReplaceProjectMemberPermissionsRequest request)
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
        public async Task DeleteMemberFromProject(long projectId, long memberId)
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
            UserStatus? status = null,
            string? search = null,
            UserTwoFactorStatus? twoFactor = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null,
            IEnumerable<OrganizationRole>? organizationRoles = null,
            long? teamId = null,
            IEnumerable<long>? projectIds = null,
            IEnumerable<ProjectRole>? projectRoles = null,
            IEnumerable<string>? languageIds = null,
            IEnumerable<long>? groupIds = null,
            DateTimeOffset? lastSeenFrom = null,
            DateTimeOffset? lastSeenTo = null)
        {
            return ListUsers(new EnterpriseUsersListParams
            {
                Limit = limit,
                Offset = offset,
                Status = status,
                Search = search,
                TwoFactor = twoFactor,
                OrderBy = orderBy,
                OrganizationRoles = organizationRoles,
                TeamId = teamId,
                ProjectIds = projectIds,
                ProjectRoles = projectRoles,
                LanguageIds = languageIds,
                GroupIds = groupIds,
                LastSeenFrom = lastSeenFrom,
                LastSeenTo = lastSeenTo
            });
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
        /// Invite user. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.users.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<UserEnterprise> InviteUser(EnterpriseInviteUserRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest("/users", request);
            return _jsonParser.ParseResponseObject<UserEnterprise>(result.JsonObject);
        }

        /// <summary>
        /// Get user. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.users.getById">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<UserEnterprise> GetUser(long userId)
        {
            var url = $"/users/{userId}";
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<UserEnterprise>(result.JsonObject);
        }

        /// <summary>
        /// Delete user. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.users.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteUser(long userId)
        {
            string url = FormUrl_UserId(userId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"User {userId} removal failed");
        }
        
        /// <summary>
        /// Edit user. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.users.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<UserEnterprise> EditUser(long userId, IEnumerable<EnterpriseUserPatch> patches)
        {
            string url = FormUrl_UserId(userId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
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
        public async Task<TeamMember> GetMemberInfo(long projectId, long memberId)
        {
            string url = FormUrl_MemberId(projectId, memberId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TeamMember>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Members(long projectId)
        {
            return $"/projects/{projectId}/members";
        }
        
        private static string FormUrl_MemberId(long projectId, long memberId)
        {
            return $"/projects/{projectId}/members/{memberId}";
        }

        private static string FormUrl_UserId(long userId)
        {
            return $"/users/{userId}";
        }

        #endregion
        
        #region Group Managers

        /// <summary>
        /// List Group Managers. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Users/operation/api.groups.managers.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<GroupManager>> ListGroupManagers(
            long groupId,
            IEnumerable<long>? teamIds = null,
            IEnumerable<SortingRule>? orderBy = null)
        {
            string url = FormUrl_GroupManagers(groupId);

            var queryParams = new Dictionary<string, string>(0);
            queryParams.AddParamIfPresent("teamIds", teamIds);
            queryParams.AddSortingRulesIfPresent(orderBy);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<GroupManager>(result.JsonObject);
        }

        /// <summary>
        /// Update Group Managers. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Users/operation/api.groups.managers.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<GroupManager>> UpdateGroupManagers(
            long groupId,
            IEnumerable<GroupManagerPatch> patches)
        {
            string url = FormUrl_GroupManagers(groupId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseList<GroupManager>(result.JsonObject);
        }

        /// <summary>
        /// Get Group Manager. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Users/operation/api.groups.managers.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GroupManager> GetGroupManager(long groupId, long userId)
        {
            string url = FormUrl_GroupManagerId(groupId, userId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<GroupManager>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_GroupManagers(long groupId)
        {
            return $"/groups/{groupId}/managers";
        }
        
        private static string FormUrl_GroupManagerId(long groupId, long userId)
        {
            return $"/groups/{groupId}/managers/{userId}";
        }

        #endregion

        #endregion
    }
}