
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

        /// <summary>
        /// List groups. Documentation:
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.groups.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Group>> ListGroups(int? parentId, int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("parentId", parentId);

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
        public async Task<Group> GetGroup(int groupId)
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
        public async Task DeleteGroup(int groupId)
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

        /// <summary>
        /// List projects. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.getMany">Crowdin Enterprise API</a>
        /// </summary>
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
        public async Task<T> GetProject<T>(int projectId)
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
        public async Task DeleteProject(int projectId)
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

        #region Project File Formats Settings
        
        /// <summary>
        /// Download Project File Format Settings Custom Segmentation. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.file-format-settings.custom-segmentations.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.file-format-settings.custom-segmentations.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadProjectFileFormatSettingsCustomSegmentation(
            int projectId,
            int fileFormatSettingsId)
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
            int projectId,
            int fileFormatSettingsId)
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
        public async Task<ResponseList<FileFormatSettingsResource>> ListProjectFileFormatSettings(int projectId)
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
            int projectId,
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
            int projectId,
            int fileFormatSettingsId)
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
            int projectId,
            int fileFormatSettingsId)
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
            int projectId,
            int fileFormatSettingsId,
            IEnumerable<ProjectFileFormatSettingsPatch> patches)
        {
            string url = FormUrl_ProjectFileFormatSettingsId(projectId, fileFormatSettingsId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<FileFormatSettingsResource>(result.JsonObject);
        }
        
        #region Helper methods
        
        private static string FormUrl_ProjectFileFormatSettings(int projectId)
        {
            return $"/projects/{projectId}/file-format-settings";
        }
        
        private static string FormUrl_ProjectFileFormatSettingsId(
            int projectId,
            int fileFormatSettingsId)
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
        public async Task<ResponseList<StringsExporterSettingsResource>> ListProjectStringsExporterSettings(int projectId)
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
            int projectId,
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
            int projectId,
            int stringsExporterSettingsId)
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
            int projectId,
            int stringsExporterSettingsId)
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
            int projectId,
            int stringsExporterSettingsId,
            IEnumerable<ProjectStringsExporterSettingsPatch> patches)
        {
            string url = FormUrl_ProjectStringsExporterSettingsId(projectId, stringsExporterSettingsId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<StringsExporterSettingsResource>(result.JsonObject);
        }
        
        #region Helper methods

        private static string FormUrl_ProjectStringsExporterSettings(int projectId)
        {
            return $"/projects/{projectId}/strings-exporter-settings";
        }

        private static string FormUrl_ProjectStringsExporterSettingsId(
            int projectId,
            int stringsExporterSettingsId)
        {
            return $"/projects/{projectId}/strings-exporter-settings/{stringsExporterSettingsId}";
        }
        
        #endregion

        #endregion
    }
}