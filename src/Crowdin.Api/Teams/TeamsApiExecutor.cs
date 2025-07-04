
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;
using Crowdin.Api.ProjectsGroups;

#nullable enable

namespace Crowdin.Api.Teams
{
    public class TeamsApiExecutor : ITeamsApiExecutor
    {
        private const string BaseUrl = "/teams";
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public TeamsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public TeamsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// Add team to project. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.teams.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ProjectTeamResources> AddTeamToProject(long projectId, AddTeamToProjectRequest request)
        {
            var url = $"/projects/{projectId}/teams";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<ProjectTeamResources>(result.JsonObject);
        }

        /// <summary>
        /// List teams. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.teams.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<Team>> ListTeams(
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null,
            IEnumerable<ProjectRole>? projectRoles = null,
            IEnumerable<string>? languageIds = null,
            IEnumerable<long>? groupIds = null)
        {
            return ListTeams(new TeamsListParams
            {
                Limit = limit,
                Offset = offset,
                OrderBy = orderBy,
                ProjectRoles = projectRoles,
                LanguageIds = languageIds,
                GroupIds = groupIds
            });
        }

        /// <summary>
        /// List teams. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.teams.getMany">Crowdin Enterprise API</a>
        /// </summary>
        public async Task<ResponseList<Team>> ListTeams(TeamsListParams @params)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseUrl, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<Team>(result.JsonObject);
        }

        /// <summary>
        /// Add team. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.teams.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Team> AddTeam(AddTeamRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(BaseUrl, request);
            return _jsonParser.ParseResponseObject<Team>(result.JsonObject);
        }

        /// <summary>
        /// Get team. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.teams.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Team> GetTeam(long teamId)
        {
            string url = FormUrl_TeamId(teamId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Team>(result.JsonObject);
        }

        /// <summary>
        /// Delete team. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.teams.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteTeam(long teamId)
        {
            string url = FormUrl_TeamId(teamId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Team {teamId} removal failed");
        }

        /// <summary>
        /// Edit team. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.teams.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Team> EditTeam(long teamId, IEnumerable<TeamPatch> patches)
        {
            string url = FormUrl_TeamId(teamId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Team>(result.JsonObject);
        }

        /// <summary>
        /// List team members. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.teams.members.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TeamMember>> ListTeamMembers(long teamId, int limit = 25, int offset = 0)
        {
            string url = FormUrl_TeamMembers(teamId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<TeamMember>(result.JsonObject);
        }

        /// <summary>
        /// Add team members. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.teams.members.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AddTeamMembersResponse> AddTeamMembers(long teamId, AddTeamMembersRequest request)
        {
            string url = FormUrl_TeamMembers(teamId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);

            return new AddTeamMembersResponse
            {
                Skipped = _jsonParser.ParseArray<TeamMember>(result.JsonObject["skipped"]!),
                Added = _jsonParser.ParseArray<TeamMember>(result.JsonObject["added"]!),
                Pagination = _jsonParser.ParseResponseObject<Pagination>(result.JsonObject["pagination"]!)
            };
        }

        /// <summary>
        /// Delete all team members. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.teams.members.deleteMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteAllTeamMembers(long teamId)
        {
            string url = FormUrl_TeamMembers(teamId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"All team members removal failed");
        }

        /// <summary>
        /// Delete team member. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.teams.members.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteTeamMember(long teamId, long memberId)
        {
            var url = $"{BaseUrl}/{teamId}/members/{memberId}";
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Team member {memberId} removal failed");
        }

        #region Helper methods

        private static string FormUrl_TeamId(long teamId)
        {
            return $"{BaseUrl}/{teamId}";
        }

        private static string FormUrl_TeamMembers(long teamId)
        {
            return $"{BaseUrl}/{teamId}/members";
        }

        #endregion
        
        #region Group Teams

        /// <summary>
        /// List Group Teams. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Teams/operation/api.groups.teams.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<GroupTeam>> ListGroupTeams(
            long groupId,
            IEnumerable<SortingRule>? orderBy = null)
        {
            string url = FormUrl_GroupTeams(groupId);

            var queryParams = new Dictionary<string, string>(0);
            queryParams.AddSortingRulesIfPresent(orderBy);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<GroupTeam>(result.JsonObject);
        }

        /// <summary>
        /// Update Group Teams. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Teams/operation/api.groups.teams.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<GroupTeam>> UpdateGroupTeams(
            long groupId,
            IEnumerable<GroupTeamPatch> patches)
        {
            string url = FormUrl_GroupTeams(groupId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseList<GroupTeam>(result.JsonObject);
        }

        /// <summary>
        /// Get Group Team. Documentation:
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/Teams/operation/api.groups.teams.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<GroupTeam> GetGroupTeam(long groupId, long teamId)
        {
            string url = FormUrl_GroupTeamId(groupId, teamId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<GroupTeam>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_GroupTeams(long groupId)
        {
            return $"/groups/{groupId}/teams";
        }

        private static string FormUrl_GroupTeamId(long groupId, long teamId)
        {
            return $"/groups/{groupId}/teams/{teamId}";
        }

        #endregion

        #endregion
    }
}