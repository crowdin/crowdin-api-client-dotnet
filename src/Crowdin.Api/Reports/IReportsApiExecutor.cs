
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public interface IReportsApiExecutor
    {
        #region Report Archives

        Task<ResponseList<ReportArchive>> ListReportArchives(
            int? userId,
            ScopeType? scopeType = null,
            int? scopeId = null,
            int limit = 25,
            int offset = 0);

        Task<ReportArchive> GetReportArchive(int? userId, int archiveId);

        Task DeleteReportArchive(int? userId, int archiveId);

        Task<GroupReportStatus> ExportReportArchive(
            int? userId,
            int archiveId,
            ExportReportArchiveRequest request);

        Task<GroupReportStatus> CheckReportArchiveExportStatus(
            int? userId,
            int archiveId,
            string exportId);

        Task<DownloadLink> DownloadReportArchive(int? userId, int archiveId, string exportId);

        #endregion

        #region Group Reports

        Task<GroupReportStatus> GenerateGroupReport(int groupId, GenerateGroupReportRequest request);

        Task<GroupReportStatus> CheckGroupReportGenerationStatus(int groupId, int reportId);

        Task<DownloadLink> DownloadGroupReport(int groupId, int reportId);

        #endregion

        #region Organization Reports

        Task<GroupReportStatus> GenerateOrganizationReport(GenerateGroupReportRequest request);

        Task<GroupReportStatus> CheckOrganizationReportGenerationStatus(int reportId);

        Task<DownloadLink> DownloadOrganizationReport(int reportId);

        #endregion

        #region Reports

        Task<ReportStatus> GenerateReport(int projectId, GenerateReportRequest request);

        Task<ReportStatus> CheckReportGenerationStatus(int projectId, string reportId);

        Task<DownloadLink> DownloadReport(int projectId, string reportId);

        #endregion

        #region Report Settings Templates

        Task<ResponseList<ReportSettingsTemplateBase>> ListReportSettingsTemplates(
            int projectId,
            int limit = 25,
            int offset = 0);

        Task<ReportSettingsTemplateBase> AddReportSettingsTemplate(
            int projectId,
            AddReportSettingsTemplateRequest request);

        Task<ReportSettingsTemplateBase> GetReportSettingsTemplate(
            int projectId,
            int reportSettingsTemplateId);

        Task<ReportSettingsTemplateBase> EditReportSettingsTemplate(
            int projectId,
            int reportSettingsTemplateId,
            IEnumerable<ReportSettingsTemplatePatch> patches);

        Task DeleteReportSettingsTemplate(int projectId, int reportSettingsTemplateId);

        #endregion
    }
}