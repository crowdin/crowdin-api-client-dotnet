
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.ProjectsGroups
{
    public class ProjectsGroupsApiExecutor
    {
        private const string BaseGroupsSubUrl = "/groups";
        private const string BaseProjectsSubUrl = "/projects";
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public ProjectsGroupsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public ProjectsGroupsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        #region Groups

        [PublicAPI]
        public async Task<ResponseList<Group>> ListGroups(int? parentId, int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("parentId", parentId);

            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseGroupsSubUrl, queryParams);
            return _jsonParser.ParseResponseList<Group>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Group> AddGroup(AddGroupRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(BaseGroupsSubUrl, request);
            return _jsonParser.ParseResponseObject<Group>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Group> GetGroup(int groupId)
        {
            string url = FormUrl_GroupId(groupId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Group>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteGroup(int groupId)
        {
            string url = FormUrl_GroupId(groupId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Group {groupId} removal failed");
        }

        [PublicAPI]
        public async Task<Group> EditGroup(int groupId, IEnumerable<GroupPatch> patches)
        {
            string url = FormUrl_GroupId(groupId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Group>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_GroupId(int groupId) => $"{BaseGroupsSubUrl}/{groupId}";

        #endregion

        #endregion

        #region Projects

        [PublicAPI]
        public async Task<ResponseList<TProject>> ListProjects<TProject>(
            int? userId = null, int? groupId = null,
            bool hasManagerAccess = false,
            int limit = 25, int offset = 0)
                where TProject : ProjectBase // Project, EnterpriseProject
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("userId", userId);
            queryParams.AddParamIfPresent("groupId", groupId);
            queryParams.Add("hasManagerAccess", hasManagerAccess ? "1" : "0");

            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseProjectsSubUrl, queryParams);
            
            return _jsonParser.ParseResponseList<TProject>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<T> AddProject<T>(AddProjectRequest request)
            where T : ProjectBase // Project { ProjectSettings }, EnterpriseProject
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(BaseProjectsSubUrl, request);
            return _jsonParser.ParseResponseObject<T>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<T> GetProject<T>(int projectId)
            where T : ProjectBase
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest(FormUrl_ProjectId(projectId));
            return _jsonParser.ParseResponseObject<T>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteProject(int projectId)
        {
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(FormUrl_ProjectId(projectId));
            Utils.ThrowIfStatusNot204(statusCode, $"Project {projectId} removal failed");
        }

        [PublicAPI]
        public async Task<T> EditProject<T>(int projectId, IEnumerable<ProjectPatch> patches)
            where T : ProjectBase
        {
            CrowdinApiResult result = await _apiClient.SendPatchRequest(FormUrl_ProjectId(projectId), patches);
            return _jsonParser.ParseResponseObject<T>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_ProjectId(int projectId) => $"{BaseProjectsSubUrl}/{projectId.ToString()}";

        #endregion

        #endregion
    }
}