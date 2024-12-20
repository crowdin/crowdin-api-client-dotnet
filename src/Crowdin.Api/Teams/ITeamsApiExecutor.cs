
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

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
            IEnumerable<SortingRule>? orderBy = null);

        Task<Team> AddTeam(AddTeamRequest request);

        Task<Team> GetTeam(int teamId);

        Task DeleteTeam(int teamId);

        Task<Team> EditTeam(int teamId, IEnumerable<TeamPatch> patches);

        Task<ResponseList<TeamMember>> ListTeamMembers(int teamId, int limit = 25, int offset = 0);

        Task<AddTeamMembersResponse> AddTeamMembers(int teamId, AddTeamMembersRequest request);

        Task DeleteAllTeamMembers(int teamId);

        Task DeleteTeamMember(int teamId, int memberId);
    }
}