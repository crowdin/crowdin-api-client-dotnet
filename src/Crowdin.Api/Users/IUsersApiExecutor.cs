
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.ProjectsGroups;

#nullable enable

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public interface IUsersApiExecutor
    {
        Task<ResponseList<TeamMember>> ListProjectMembers(
            int projectId,
            string? search = null,
            UserRole? role = null,
            string? languageId = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<TeamMember>> ListProjectMembers(int projectId, ProjectMembersListParams @params);

        Task<ResponseList<ProjectMember>> ListProjectMembersEnterprise(
            int projectId,
            string? search = null,
            string? languageId = null,
            int? workflowStepId = null,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<ProjectMember>> ListProjectMembersEnterprise(
            int projectId,
            EnterpriseProjectMembersListParams @params);

        Task<ProjectMembersResponse> AddProjectMember(int projectId, AddProjectMemberRequest request);

        Task<ProjectMember> GetProjectMemberPermissions(int projectId, int memberId);

        Task<ProjectMember> ReplaceProjectMemberPermissions(
            int projectId,
            int memberId,
            ReplaceProjectMemberPermissionsRequest request);

        Task DeleteMemberFromProject(int projectId, int memberId);

        Task<ResponseList<UserEnterprise>> ListUsers(
            UserStatus? status = null,
            string? search = null,
            UserTwoFactorStatus? twoFactor = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null,
            IEnumerable<OrganizationRole>? organizationRoles = null,
            int? teamId = null,
            IEnumerable<int>? projectIds = null,
            IEnumerable<ProjectRole>? projectRoles = null,
            IEnumerable<string>? languageIds = null,
            IEnumerable<int>? groupIds = null,
            DateTimeOffset? lastSeenFrom = null,
            DateTimeOffset? lastSeenTo = null);

        Task<ResponseList<UserEnterprise>> ListUsers(EnterpriseUsersListParams @params);

        Task<UserEnterprise> InviteUser(EnterpriseInviteUserRequest request);

        Task<UserEnterprise> GetUser(int userId);

        Task DeleteUser(int userId);

        Task<UserEnterprise> EditUser(int userId, IEnumerable<EnterpriseUserPatch> patches);

        Task<T> GetAuthenticatedUser<T>() where T : UserBase;

        Task<TeamMember> GetMemberInfo(int projectId, int memberId);

        #region Group Managers

        Task<ResponseList<GroupManager>> ListGroupManagers(
            int groupId,
            IEnumerable<int>? teamIds = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<GroupManager>> UpdateGroupManagers(
            int groupId,
            IEnumerable<GroupManagerPatch> patches);

        Task<GroupManager> GetGroupManager(int groupId, int userId);

        #endregion
    }
}