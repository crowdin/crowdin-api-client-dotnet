
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
            long projectId,
            string? search = null,
            UserRole? role = null,
            string? languageId = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<TeamMember>> ListProjectMembers(long projectId, ProjectMembersListParams @params);

        Task<ResponseList<ProjectMember>> ListProjectMembersEnterprise(
            long projectId,
            string? search = null,
            string? languageId = null,
            long? workflowStepId = null,
            int limit = 25,
            int offset = 0);

        Task<ResponseList<ProjectMember>> ListProjectMembersEnterprise(
            long projectId,
            EnterpriseProjectMembersListParams @params);

        Task<ProjectMembersResponse> AddProjectMember(long projectId, AddProjectMemberRequest request);

        Task<ProjectMember> GetProjectMemberPermissions(long projectId, long memberId);

        Task<ProjectMember> ReplaceProjectMemberPermissions(
            long projectId,
            long memberId,
            ReplaceProjectMemberPermissionsRequest request);

        Task DeleteMemberFromProject(long projectId, long memberId);

        Task<ResponseList<UserEnterprise>> ListUsers(
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
            DateTimeOffset? lastSeenTo = null);

        Task<ResponseList<UserEnterprise>> ListUsers(EnterpriseUsersListParams @params);

        Task<UserEnterprise> InviteUser(EnterpriseInviteUserRequest request);

        Task<UserEnterprise> GetUser(long userId);

        Task DeleteUser(long userId);

        Task<UserEnterprise> EditUser(long userId, IEnumerable<EnterpriseUserPatch> patches);

        Task<T> GetAuthenticatedUser<T>() where T : UserBase;

        Task<TeamMember> GetMemberInfo(long projectId, long memberId);

        #region Group Managers

        Task<ResponseList<GroupManager>> ListGroupManagers(
            long groupId,
            IEnumerable<long>? teamIds = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<GroupManager>> UpdateGroupManagers(
            long groupId,
            IEnumerable<GroupManagerPatch> patches);

        Task<GroupManager> GetGroupManager(long groupId, long userId);

        #endregion
    }
}