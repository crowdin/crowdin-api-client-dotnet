
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Tasks
{
    public class TasksApiExecutor : ITasksApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public TasksApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }
        
        public TasksApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List tasks. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.tasks.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.tasks.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<TaskResource>> ListTasks(
            int projectId,
            int limit = 25,
            int offset = 0,
            TaskStatus? status = null,
            int? assigneeId = null,
            IEnumerable<SortingRule>? orderBy = null)
        {
            return ListTasks(projectId, new TasksListParams(limit, offset, status, assigneeId, orderBy));
        }

        /// <summary>
        /// List tasks. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.tasks.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.tasks.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TaskResource>> ListTasks(int projectId, TasksListParams @params)
        {
            string url = FormUrl_Tasks(projectId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, @params.ToQueryParams());
            return _jsonParser.ParseResponseList<TaskResource>(result.JsonObject);
        }

        /// <summary>
        /// Add task. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.tasks.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.tasks.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TaskResource> AddTask(int projectId, AddTaskRequest request)
        {
            string url = FormUrl_Tasks(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<TaskResource>(result.JsonObject);
        }

        /// <summary>
        /// Export task strings. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.tasks.exports.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.tasks.exports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink?> ExportTaskStrings(int projectId, int taskId)
        {
            var url = $"/projects/{projectId}/tasks/{taskId}/exports";
            CrowdinApiResult result = await _apiClient.SendPostRequest(url);

            return result.JsonObject.TryGetValue("data", out _)
                ? _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject)
                : null;
        }

        /// <summary>
        /// Get task. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.tasks.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.tasks.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TaskResource> GetTask(int projectId, int taskId)
        {
            string url = FormUrl_TaskId(projectId, taskId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TaskResource>(result.JsonObject);
        }

        /// <summary>
        /// Delete task. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.tasks.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.tasks.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteTask(int projectId, int taskId)
        {
            string url = FormUrl_TaskId(projectId, taskId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Task {taskId} removal failed");
        }

        /// <summary>
        /// Edit task. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.tasks.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.tasks.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TaskResource> EditTask(int projectId, int taskId, IEnumerable<TaskPatchBase> patches)
        {
            string url = FormUrl_TaskId(projectId, taskId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<TaskResource>(result.JsonObject);
        }

        /// <summary>
        /// List user tasks. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.user.tasks.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.user.tasks.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public Task<ResponseList<TaskResource>> ListUserTasks(
            int limit = 25,
            int offset = 0,
            TaskStatus? status = null,
            bool? isArchived = null,
            IEnumerable<SortingRule>? orderBy = null)
        {
            return ListUserTasks(new UserTasksListParams(limit, offset, status, isArchived, orderBy));
        }

        /// <summary>
        /// List user tasks. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.user.tasks.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.user.tasks.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TaskResource>> ListUserTasks(UserTasksListParams @params)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest("/user/tasks", @params.ToQueryParams());
            return _jsonParser.ParseResponseList<TaskResource>(result.JsonObject);
        }

        /// <summary>
        /// Edit task archived status. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.user.tasks.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.user.tasks.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TaskResource> EditTaskArchivedStatus(
            int projectId,
            int taskId,
            IEnumerable<TaskArchivedStatusPatch> patches)
        {
            var url = $"/user/tasks/{taskId}";
            var queryParams = new Dictionary<string, string>
            {
                { "projectId", projectId.ToString() }
            };
            
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches, queryParams);
            return _jsonParser.ParseResponseObject<TaskResource>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Tasks(int projectId)
        {
            return $"/projects/{projectId}/tasks";
        }

        private static string FormUrl_TaskId(int projectId, int taskId)
        {
            return $"/projects/{projectId}/tasks/{taskId}";
        }

        #endregion

        #region Task Settings Templates
        
        /// <summary>
        /// List Task Settings Templates. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.tasks.settings-templates.getMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.tasks.settings-templates.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<TaskSettingsTemplate>> ListTaskSettingsTemplates(
            int projectId,
            int limit = 25,
            int offset = 0)
        {
            string url = FormUrl_TaskSettingsTemplates(projectId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<TaskSettingsTemplate>(result.JsonObject);
        }
        
        /// <summary>
        /// Add Task Settings Template. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.tasks.settings-templates.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.tasks.settings-templates.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TaskSettingsTemplate> AddTaskSettingsTemplate(int projectId, AddTaskSettingsTemplate request)
        {
            string url = FormUrl_TaskSettingsTemplates(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<TaskSettingsTemplate>(result.JsonObject);
        }
        
        /// <summary>
        /// Get Task Settings Template. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.tasks.settings-templates.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.tasks.settings-templates.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TaskSettingsTemplate> GetTaskSettingsTemplate(int projectId, int taskSettingsTemplateId)
        {
            string url = FormUrl_TaskSettingsTemplateId(projectId, taskSettingsTemplateId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<TaskSettingsTemplate>(result.JsonObject);
        }
        
        /// <summary>
        /// Delete Task Settings Template. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.tasks.settings-templates.delete">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.tasks.settings-templates.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteTaskSettingsTemplate(int projectId, int taskSettingsTemplateId)
        {
            string url = FormUrl_TaskSettingsTemplateId(projectId, taskSettingsTemplateId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Task Settings Template {taskSettingsTemplateId} removal failed");
        }
        
        /// <summary>
        /// Edit Task Settings Template. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.projects.tasks.settings-templates.patch">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.projects.tasks.settings-templates.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<TaskSettingsTemplate> EditTaskSettingsTemplate(
            int projectId,
            int taskSettingsTemplateId,
            IEnumerable<TaskSettingsTemplatePatch> patches)
        {
            string url = FormUrl_TaskSettingsTemplateId(projectId, taskSettingsTemplateId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<TaskSettingsTemplate>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_TaskSettingsTemplates(int projectId)
        {
            return $"/projects/{projectId}/tasks/settings-templates";
        }

        private static string FormUrl_TaskSettingsTemplateId(int projectId, int taskSettingsTemplateId)
        {
            return $"/projects/{projectId}/tasks/settings-templates/{taskSettingsTemplateId}";
        }

        #endregion

        #endregion
    }
}