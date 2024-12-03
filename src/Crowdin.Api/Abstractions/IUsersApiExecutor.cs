
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Users;

#nullable enable

namespace Crowdin.Api.Abstractions
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
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<UserEnterprise>> ListUsers(EnterpriseUsersListParams @params);

        Task<UserEnterprise> InviteUser(EnterpriseInviteUserRequest request);

        Task<UserEnterprise> GetUser(int userId);

        Task DeleteUser(int userId);

        Task<UserEnterprise> EditUser(int userId, IEnumerable<EnterpriseUserPatch> patches);

        Task<T> GetAuthenticatedUser<T>() where T : UserBase;

        Task<TeamMember> GetMemberInfo(int projectId, int memberId);
    }
}