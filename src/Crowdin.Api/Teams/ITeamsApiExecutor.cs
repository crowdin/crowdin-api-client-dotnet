
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
        Task<ProjectTeamResources> AddTeamToProject(int projectId, AddTeamToProjectRequest request);

        Task<ResponseList<Team>> ListTeams(
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null,
            IEnumerable<ProjectRole>? projectRoles = null,
            IEnumerable<string>? languageIds = null,
            IEnumerable<int>? groupIds = null);

        Task<ResponseList<Team>> ListTeams(TeamsListParams @params);

        Task<Team> AddTeam(AddTeamRequest request);

        Task<Team> GetTeam(int teamId);

        Task DeleteTeam(int teamId);

        Task<Team> EditTeam(int teamId, IEnumerable<TeamPatch> patches);

        Task<ResponseList<TeamMember>> ListTeamMembers(int teamId, int limit = 25, int offset = 0);

        Task<AddTeamMembersResponse> AddTeamMembers(int teamId, AddTeamMembersRequest request);

        Task DeleteAllTeamMembers(int teamId);

        Task DeleteTeamMember(int teamId, int memberId);

        #region Group Teams

        Task<ResponseList<GroupTeam>> ListGroupTeams(int groupId, IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<GroupTeam>> UpdateGroupTeams(int groupId, IEnumerable<GroupTeamPatch> patches);

        Task<GroupTeam> GetGroupTeam(int groupId, int teamId);

        #endregion
    }
}