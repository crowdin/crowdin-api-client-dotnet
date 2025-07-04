
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public interface IProjectsGroupsApiExecutor
    {
        #region Groups

        Task<ResponseList<Group>> ListGroups(
            long? parentId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<Group> AddGroup(AddGroupRequest request);

        Task<Group> GetGroup(long groupId);

        Task DeleteGroup(long groupId);

        Task<Group> EditGroup(long groupId, IEnumerable<GroupPatch> patches);

        #endregion

        #region Projects

        Task<ResponseList<TProject>> ListProjects<TProject>(
            long? userId = null,
            long? groupId = null,
            bool hasManagerAccess = false,
            ProjectType? type = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null) where TProject : ProjectBase;

        Task<T> AddProject<T>(AddProjectRequest request) where T : ProjectBase;

        Task<T> GetProject<T>(long projectId) where T : ProjectBase;

        Task DeleteProject(long projectId);

        Task<T> EditProject<T>(long projectId, IEnumerable<ProjectPatch> patches) where T : ProjectBase;

        #endregion

        #region Project File Formats Settings

        Task<DownloadLink> DownloadProjectFileFormatSettingsCustomSegmentation(
            long projectId,
            long fileFormatSettingsId);

        Task ResetProjectFileFormatSettingsCustomSegmentation(
            long projectId,
            long fileFormatSettingsId);

        Task<ResponseList<FileFormatSettingsResource>> ListProjectFileFormatSettings(long projectId);

        Task<FileFormatSettingsResource> AddProjectFileFormatSettings(
            long projectId,
            AddProjectFileFormatSettingsRequest request);

        Task<FileFormatSettingsResource> GetProjectFileFormatSettings(
            long projectId,
            long fileFormatSettingsId);

        Task DeleteProjectFileFormatSettings(
            long projectId,
            long fileFormatSettingsId);

        Task<FileFormatSettingsResource> EditProjectFileFormatSettings(
            long projectId,
            long fileFormatSettingsId,
            IEnumerable<ProjectFileFormatSettingsPatch> patches);

        #endregion

        #region Project Strings Exporter Settings

        Task<ResponseList<StringsExporterSettingsResource>> ListProjectStringsExporterSettings(long projectId);

        Task<StringsExporterSettingsResource> AddProjectStringsExporterSettings(
            long projectId,
            AddProjectStringsExporterSettingsRequest request);

        Task<StringsExporterSettingsResource> GetProjectStringsExporterSettings(
            long projectId,
            long stringsExporterSettingsId);

        Task DeleteProjectStringsExporterSettings(
            long projectId,
            long stringsExporterSettingsId);

        Task<StringsExporterSettingsResource> EditProjectStringsExporterSettings(
            long projectId,
            long stringsExporterSettingsId,
            IEnumerable<ProjectStringsExporterSettingsPatch> patches);

        #endregion
    }
}