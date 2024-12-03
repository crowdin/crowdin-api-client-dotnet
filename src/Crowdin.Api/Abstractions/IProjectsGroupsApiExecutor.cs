
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.ProjectsGroups;

#nullable enable

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IProjectsGroupsApiExecutor
    {
        #region Groups

        Task<ResponseList<Group>> ListGroups(
            int? parentId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<Group> AddGroup(AddGroupRequest request);

        Task<Group> GetGroup(int groupId);

        Task DeleteGroup(int groupId);

        Task<Group> EditGroup(int groupId, IEnumerable<GroupPatch> patches);

        #endregion

        #region Projects

        Task<ResponseList<TProject>> ListProjects<TProject>(
            int? userId = null,
            int? groupId = null,
            bool hasManagerAccess = false,
            ProjectType? type = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null) where TProject : ProjectBase;

        Task<T> AddProject<T>(AddProjectRequest request) where T : ProjectBase;

        Task<T> GetProject<T>(int projectId) where T : ProjectBase;

        Task DeleteProject(int projectId);

        Task<T> EditProject<T>(int projectId, IEnumerable<ProjectPatch> patches) where T : ProjectBase;

        #endregion

        #region Project File Formats Settings

        Task<DownloadLink> DownloadProjectFileFormatSettingsCustomSegmentation(
            int projectId,
            int fileFormatSettingsId);

        Task ResetProjectFileFormatSettingsCustomSegmentation(
            int projectId,
            int fileFormatSettingsId);

        Task<ResponseList<FileFormatSettingsResource>> ListProjectFileFormatSettings(int projectId);

        Task<FileFormatSettingsResource> AddProjectFileFormatSettings(
            int projectId,
            AddProjectFileFormatSettingsRequest request);

        Task<FileFormatSettingsResource> GetProjectFileFormatSettings(
            int projectId,
            int fileFormatSettingsId);

        Task DeleteProjectFileFormatSettings(
            int projectId,
            int fileFormatSettingsId);

        Task<FileFormatSettingsResource> EditProjectFileFormatSettings(
            int projectId,
            int fileFormatSettingsId,
            IEnumerable<ProjectFileFormatSettingsPatch> patches);

        #endregion

        #region Project Strings Exporter Settings

        Task<ResponseList<StringsExporterSettingsResource>> ListProjectStringsExporterSettings(int projectId);

        Task<StringsExporterSettingsResource> AddProjectStringsExporterSettings(
            int projectId,
            AddProjectStringsExporterSettingsRequest request);

        Task<StringsExporterSettingsResource> GetProjectStringsExporterSettings(
            int projectId,
            int stringsExporterSettingsId);

        Task DeleteProjectStringsExporterSettings(
            int projectId,
            int stringsExporterSettingsId);

        Task<StringsExporterSettingsResource> EditProjectStringsExporterSettings(
            int projectId,
            int stringsExporterSettingsId,
            IEnumerable<ProjectStringsExporterSettingsPatch> patches);

        #endregion
    }
}