
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
            long projectId,
            int limit = 25,
            int offset = 0,
            TaskStatus? status = null,
            long? assigneeId = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<TaskResource>> ListTasks(
            long projectId,
            int limit = 25,
            int offset = 0,
            IEnumerable<TaskStatus>? statuses = null,
            long? assigneeId = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<TaskResource>> ListTasks(long projectId, TasksListParams @params);

        Task<TaskResource> AddTask(long projectId, AddTaskRequest request);

        Task<DownloadLink?> ExportTaskStrings(long projectId, long taskId);

        Task<TaskResource> GetTask(long projectId, long taskId);

        Task DeleteTask(long projectId, long taskId);

        Task<TaskResource> EditTask(long projectId, long taskId, IEnumerable<TaskPatchBase> patches);

        Task<ResponseList<TaskResource>> ListUserTasks(
            int limit = 25,
            int offset = 0,
            TaskStatus? status = null,
            bool? isArchived = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<TaskResource>> ListUserTasks(UserTasksListParams @params);

        Task<TaskResource> EditTaskArchivedStatus(
            long projectId,
            long taskId,
            IEnumerable<TaskArchivedStatusPatch> patches);

        #region Task Settings Templates

        Task<ResponseList<TaskSettingsTemplate>> ListTaskSettingsTemplates(
            long projectId,
            int limit = 25,
            int offset = 0);

        Task<TaskSettingsTemplate> AddTaskSettingsTemplate(long projectId, AddTaskSettingsTemplate request);

        Task<TaskSettingsTemplate> GetTaskSettingsTemplate(long projectId, long taskSettingsTemplateId);

        Task DeleteTaskSettingsTemplate(long projectId, long taskSettingsTemplateId);

        Task<TaskSettingsTemplate> EditTaskSettingsTemplate(
            long projectId,
            long taskSettingsTemplateId,
            IEnumerable<TaskSettingsTemplatePatch> patches);

        #endregion

        #region Task Comments

        Task<ResponseList<TaskComment>> ListTaskComments(
            long projectId,
            long taskId,
            int limit = 25,
            int offset = 0);

        Task<TaskComment> AddTaskComment(long projectId, long taskId, AddTaskCommentRequest request);

        Task<TaskComment> GetTaskComment(long projectId, long taskId, long commentId);
        
        Task DeleteTaskComment(long projectId, long taskId, long commentId);

        Task<TaskComment> EditTaskComment(
            long projectId,
            long taskId,
            long commentId,
            IEnumerable<TaskCommentPatch> patches);

        #endregion
    }
}