
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public interface ITasksApiExecutor
    {
        Task<ResponseList<TaskResource>> ListTasks(
            int projectId,
            int limit = 25,
            int offset = 0,
            TaskStatus? status = null,
            int? assigneeId = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<TaskResource>> ListTasks(
            int projectId,
            int limit = 25,
            int offset = 0,
            IEnumerable<TaskStatus>? statuses = null,
            int? assigneeId = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<TaskResource>> ListTasks(int projectId, TasksListParams @params);

        Task<TaskResource> AddTask(int projectId, AddTaskRequest request);

        Task<DownloadLink?> ExportTaskStrings(int projectId, int taskId);

        Task<TaskResource> GetTask(int projectId, int taskId);

        Task DeleteTask(int projectId, int taskId);

        Task<TaskResource> EditTask(int projectId, int taskId, IEnumerable<TaskPatchBase> patches);

        Task<ResponseList<TaskResource>> ListUserTasks(
            int limit = 25,
            int offset = 0,
            TaskStatus? status = null,
            bool? isArchived = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<TaskResource>> ListUserTasks(UserTasksListParams @params);

        Task<TaskResource> EditTaskArchivedStatus(
            int projectId,
            int taskId,
            IEnumerable<TaskArchivedStatusPatch> patches);

        #region Task Settings Templates

        Task<ResponseList<TaskSettingsTemplate>> ListTaskSettingsTemplates(
            int projectId,
            int limit = 25,
            int offset = 0);

        Task<TaskSettingsTemplate> AddTaskSettingsTemplate(int projectId, AddTaskSettingsTemplate request);

        Task<TaskSettingsTemplate> GetTaskSettingsTemplate(int projectId, int taskSettingsTemplateId);

        Task DeleteTaskSettingsTemplate(int projectId, int taskSettingsTemplateId);

        Task<TaskSettingsTemplate> EditTaskSettingsTemplate(
            int projectId,
            int taskSettingsTemplateId,
            IEnumerable<TaskSettingsTemplatePatch> patches);

        #endregion
    }
}