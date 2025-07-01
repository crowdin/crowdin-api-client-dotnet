
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.ProjectsGroups
{
    public class ProjectsGroupsApiExecutor : IProjectsGroupsApiExecutor
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

        /// <summary>
        /// List groups. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.groups.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Group>> ListGroups(
            long? parentId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("parentId", parentId);
            queryParams.AddSortingRulesIfPresent(orderBy);

            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseGroupsSubUrl, queryParams);
            return _jsonParser.ParseResponseList<Group>(result.JsonObject);
        }

        /// <summary>
        /// Add group. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.groups.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Group> AddGroup(AddGroupRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(BaseGroupsSubUrl, request);
            return _jsonParser.ParseResponseObject<Group>(result.JsonObject);
        }

        /// <summary>
        /// Get group. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.groups.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Group> GetGroup(long groupId)
        {
            string url = FormUrl_GroupId(groupId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Group>(result.JsonObject);
        }

        /// <summary>
        /// Delete group. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.groups.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteGroup(long groupId)
        {
            string url = FormUrl_GroupId(groupId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Group {groupId} removal failed");
        }

        /// <summary>
        /// Edit group. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.groups.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Group> EditGroup(long groupId, IEnumerable<GroupPatch> patches)
        {
            string url = FormUrl_GroupId(groupId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Group>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_GroupId(long groupId) => $"{BaseGroupsSubUrl}/{groupId}";

        #endregion

        #endregion

        #region Projects

        /// <summary>
        /// List projects. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TProject>> ListProjects<TProject>(
            long? userId = null,
            long? groupId = null,
            bool hasManagerAccess = false,
            ProjectType? type = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null)
                where TProject : ProjectBase // Project, EnterpriseProject
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("userId", userId);
            queryParams.AddParamIfPresent("groupId", groupId);
            queryParams.Add("hasManagerAccess", hasManagerAccess ? "1" : "0");
            queryParams.AddSortingRulesIfPresent(orderBy);
            
            if (type.HasValue)
            {
                queryParams.Add("type", ((int) type).ToString());
            }

            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseProjectsSubUrl, queryParams);
            
            return _jsonParser.ParseResponseList<TProject>(result.JsonObject);
        }

        /// <summary>
        /// Add project. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<T> AddProject<T>(AddProjectRequest request)
            where T : ProjectBase // Project { ProjectSettings }, EnterpriseProject
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(BaseProjectsSubUrl, request);
            return _jsonParser.ParseResponseObject<T>(result.JsonObject);
        }

        /// <summary>
        /// Get project. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<T> GetProject<T>(long projectId)
            where T : ProjectBase
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest(FormUrl_ProjectId(projectId));
            return _jsonParser.ParseResponseObject<T>(result.JsonObject);
        }

        /// <summary>
        /// Delete project. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteProject(long projectId)
        {
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(FormUrl_ProjectId(projectId));
            Utils.ThrowIfStatusNot204(statusCode, $"Project {projectId} removal failed");
        }

        /// <summary>
        /// Edit project. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<T> EditProject<T>(long projectId, IEnumerable<ProjectPatch> patches)
            where T : ProjectBase
        {
            CrowdinApiResult result = await _apiClient.SendPatchRequest(FormUrl_ProjectId(projectId), patches);
            return _jsonParser.ParseResponseObject<T>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_ProjectId(long projectId) => $"{BaseProjectsSubUrl}/{projectId.ToString()}";

        #endregion

        #endregion

        #region Project File Formats Settings
        
        /// <summary>
        /// Download Project File Format Settings Custom Segmentation. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.file-format-settings.custom-segmentations.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.file-format-settings.custom-segmentations.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadProjectFileFormatSettingsCustomSegmentation(
            long projectId,
            long fileFormatSettingsId)
        {
            string url = FormUrl_ProjectFileFormatSettingsId(projectId, fileFormatSettingsId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }
        
        /// <summary>
        /// Reset Project File Format Settings Custom Segmentation. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.file-format-settings.custom-segmentations.delete">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.file-format-settings.custom-segmentations.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task ResetProjectFileFormatSettingsCustomSegmentation(
            long projectId,
            long fileFormatSettingsId)
        {
            string url = FormUrl_ProjectFileFormatSettingsId(projectId, fileFormatSettingsId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Project file format settings custom segmentation" +
                                                  $"{fileFormatSettingsId} removal failed");
        }
        
        /// <summary>
        /// List Project File Format Settings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.file-format-settings.getMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.file-format-settings.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<FileFormatSettingsResource>> ListProjectFileFormatSettings(long projectId)
        {
            string url = FormUrl_ProjectFileFormatSettings(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseList<FileFormatSettingsResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Add Project File Format Settings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.file-format-settings.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.file-format-settings.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<FileFormatSettingsResource> AddProjectFileFormatSettings(
            long projectId,
            AddProjectFileFormatSettingsRequest request)
        {
            string url = FormUrl_ProjectFileFormatSettings(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<FileFormatSettingsResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Get Project File Format Settings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.file-format-settings.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.file-format-settings.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<FileFormatSettingsResource> GetProjectFileFormatSettings(
            long projectId,
            long fileFormatSettingsId)
        {
            string url = FormUrl_ProjectFileFormatSettingsId(projectId, fileFormatSettingsId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<FileFormatSettingsResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Delete Project File Format Settings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.file-format-settings.delete">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.file-format-settings.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteProjectFileFormatSettings(
            long projectId,
            long fileFormatSettingsId)
        {
            string url = FormUrl_ProjectFileFormatSettingsId(projectId, fileFormatSettingsId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Project File Format Settings {fileFormatSettingsId} removal failed");
        }
        
        /// <summary>
        /// Edit Project File Format Settings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.file-format-settings.patch">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.file-format-settings.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<FileFormatSettingsResource> EditProjectFileFormatSettings(
            long projectId,
            long fileFormatSettingsId,
            IEnumerable<ProjectFileFormatSettingsPatch> patches)
        {
            string url = FormUrl_ProjectFileFormatSettingsId(projectId, fileFormatSettingsId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<FileFormatSettingsResource>(result.JsonObject);
        }
        
        #region Helper methods
        
        private static string FormUrl_ProjectFileFormatSettings(long projectId)
        {
            return $"/projects/{projectId}/file-format-settings";
        }
        
        private static string FormUrl_ProjectFileFormatSettingsId(
            long projectId,
            long fileFormatSettingsId)
        {
            return $"/projects/{projectId}/file-format-settings/{fileFormatSettingsId}";
        }
        
        #endregion
        
        #endregion
        
        #region Project Strings Exporter Settings

        /// <summary>
        /// List Project Strings Exporter Settings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.strings-exporter-settings.getMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.strings-exporter-settings.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<StringsExporterSettingsResource>> ListProjectStringsExporterSettings(long projectId)
        {
            string url = FormUrl_ProjectStringsExporterSettings(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseList<StringsExporterSettingsResource>(result.JsonObject);
        }

        /// <summary>
        /// Add Project Strings Exporter Settings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.strings-exporter-settings.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.strings-exporter-settings.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StringsExporterSettingsResource> AddProjectStringsExporterSettings(
            long projectId,
            AddProjectStringsExporterSettingsRequest request)
        {
            string url = FormUrl_ProjectStringsExporterSettings(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<StringsExporterSettingsResource>(result.JsonObject);
        }

        /// <summary>
        /// Get Project Strings Exporter Settings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.strings-exporter-settings.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.strings-exporter-settings.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StringsExporterSettingsResource> GetProjectStringsExporterSettings(
            long projectId,
            long stringsExporterSettingsId)
        {
            string url = FormUrl_ProjectStringsExporterSettingsId(projectId, stringsExporterSettingsId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<StringsExporterSettingsResource>(result.JsonObject);
        }


        /// <summary>
        /// Delete Project Strings Exporter Settings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.strings-exporter-settings.delete">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.strings-exporter-settings.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteProjectStringsExporterSettings(
            long projectId,
            long stringsExporterSettingsId)
        {
            string url = FormUrl_ProjectStringsExporterSettingsId(projectId, stringsExporterSettingsId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Project Strings Exporter Settings {stringsExporterSettingsId} remove failed");
        }

        /// <summary>
        /// Edit Project Strings Exporter Settings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.strings-exporter-settings.patch">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.strings-exporter-settings.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<StringsExporterSettingsResource> EditProjectStringsExporterSettings(
            long projectId,
            long stringsExporterSettingsId,
            IEnumerable<ProjectStringsExporterSettingsPatch> patches)
        {
            string url = FormUrl_ProjectStringsExporterSettingsId(projectId, stringsExporterSettingsId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<StringsExporterSettingsResource>(result.JsonObject);
        }
        
        #region Helper methods

        private static string FormUrl_ProjectStringsExporterSettings(long projectId)
        {
            return $"/projects/{projectId}/strings-exporter-settings";
        }

        private static string FormUrl_ProjectStringsExporterSettingsId(
            long projectId,
            long stringsExporterSettingsId)
        {
            return $"/projects/{projectId}/strings-exporter-settings/{stringsExporterSettingsId}";
        }
        
        #endregion

        #endregion
    }
}