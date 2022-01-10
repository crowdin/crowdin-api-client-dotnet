
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Teams
{
    public class TeamsApiExecutor
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

        [PublicAPI]
        public async Task<ProjectTeamResources> AddTeamToProject(int projectId, AddTeamToProjectRequest request)
        {
            var url = $"/projects/{projectId}/teams";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<ProjectTeamResources>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<ResponseList<Team>> ListTeams(int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);

            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseUrl, queryParams);
            return _jsonParser.ParseResponseList<Team>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Team> AddTeam(AddTeamRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(BaseUrl, request);
            return _jsonParser.ParseResponseObject<Team>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Team> GetTeam(int teamId)
        {
            string url = FormUrl_TeamId(teamId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Team>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteTeam(int teamId)
        {
            string url = FormUrl_TeamId(teamId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Team {teamId} removal failed");
        }

        [PublicAPI]
        public async Task<Team> EditTeam(int teamId, IEnumerable<TeamPatch> patches)
        {
            string url = FormUrl_TeamId(teamId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Team>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<ResponseList<TeamMember>> ListTeamMembers(int teamId, int limit = 25, int offset = 0)
        {
            string url = FormUrl_TeamMembers(teamId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<TeamMember>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<AddTeamMembersResponse> AddTeamMembers(int teamId, AddTeamMembersRequest request)
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

        [PublicAPI]
        public async Task DeleteAllTeamMembers(int teamId)
        {
            string url = FormUrl_TeamMembers(teamId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"All team members removal failed");
        }

        [PublicAPI]
        public async Task DeleteTeamMember(int teamId, int memberId)
        {
            var url = $"{BaseUrl}/{teamId}/members/{memberId}";
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Team member {memberId} removal failed");
        }

        #region Helper methods

        private static string FormUrl_TeamId(int teamId)
        {
            return $"{BaseUrl}/{teamId}";
        }

        private static string FormUrl_TeamMembers(int teamId)
        {
            return $"{BaseUrl}/{teamId}/members";
        }

        #endregion
    }
}