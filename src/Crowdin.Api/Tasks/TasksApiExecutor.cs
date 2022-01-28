
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Tasks
{
    public class TasksApiExecutor
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
            int projectId, int limit = 25, int offset = 0,
            TaskStatus? status = null, int? assigneeId = null)
        {
            return ListTasks(projectId, new TasksListParams(limit, offset, status, assigneeId));
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
            int limit = 25, int offset = 0,
            TaskStatus? status = null, bool? isArchived = null)
        {
            return ListUserTasks(new UserTasksListParams(limit, offset, status, isArchived));
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
            int projectId, int taskId, IEnumerable<TaskArchivedStatusPatch> patches)
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
    }
}