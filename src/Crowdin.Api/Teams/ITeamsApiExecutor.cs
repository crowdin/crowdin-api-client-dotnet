
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.ProjectsGroups;

#nullable enable

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public interface ITeamsApiExecutor
    {
        Task<ProjectTeamResources> AddTeamToProject(long projectId, AddTeamToProjectRequest request);

        Task<ResponseList<Team>> ListTeams(
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null,
            IEnumerable<ProjectRole>? projectRoles = null,
            IEnumerable<string>? languageIds = null,
            IEnumerable<long>? groupIds = null);

        Task<ResponseList<Team>> ListTeams(TeamsListParams @params);

        Task<Team> AddTeam(AddTeamRequest request);

        Task<Team> GetTeam(long teamId);

        Task DeleteTeam(long teamId);

        Task<Team> EditTeam(long teamId, IEnumerable<TeamPatch> patches);

        Task<ResponseList<TeamMember>> ListTeamMembers(long teamId, int limit = 25, int offset = 0);

        Task<AddTeamMembersResponse> AddTeamMembers(long teamId, AddTeamMembersRequest request);

        Task DeleteAllTeamMembers(long teamId);

        Task DeleteTeamMember(long teamId, long memberId);

        #region Group Teams

        Task<ResponseList<GroupTeam>> ListGroupTeams(long groupId, IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<GroupTeam>> UpdateGroupTeams(long groupId, IEnumerable<GroupTeamPatch> patches);

        Task<GroupTeam> GetGroupTeam(long groupId, long teamId);

        #endregion
    }
}