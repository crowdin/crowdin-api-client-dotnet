
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
            long? userId,
            ScopeType? scopeType = null,
            long? scopeId = null,
            int limit = 25,
            int offset = 0);

        Task<ReportArchive> GetReportArchive(long? userId, long archiveId);

        Task DeleteReportArchive(long? userId, long archiveId);

        Task<GroupReportStatus> ExportReportArchive(
            long? userId,
            long archiveId,
            ExportReportArchiveRequest request);

        Task<GroupReportStatus> CheckReportArchiveExportStatus(
            long? userId,
            long archiveId,
            string exportId);

        Task<DownloadLink> DownloadReportArchive(long? userId, long archiveId, string exportId);

        #endregion

        #region Group Reports

        Task<GroupReportStatus> GenerateGroupReport(long groupId, GenerateGroupReportRequest request);

        Task<GroupReportStatus> CheckGroupReportGenerationStatus(long groupId, long reportId);

        Task<DownloadLink> DownloadGroupReport(long groupId, long reportId);

        #endregion

        #region Organization Reports

        Task<GroupReportStatus> GenerateOrganizationReport(GenerateGroupReportRequest request);

        Task<GroupReportStatus> CheckOrganizationReportGenerationStatus(long reportId);

        Task<DownloadLink> DownloadOrganizationReport(long reportId);

        #endregion

        #region Reports

        Task<ReportStatus> GenerateReport(long projectId, GenerateReportRequest request);

        Task<ReportStatus> CheckReportGenerationStatus(long projectId, string reportId);

        Task<DownloadLink> DownloadReport(long projectId, string reportId);

        #endregion

        #region Report Settings Templates

        Task<ResponseList<ReportSettingsTemplateBase>> ListReportSettingsTemplates(
            long projectId,
            int limit = 25,
            int offset = 0);

        Task<ReportSettingsTemplateBase> AddReportSettingsTemplate(
            long projectId,
            AddReportSettingsTemplateRequest request);

        Task<ReportSettingsTemplateBase> GetReportSettingsTemplate(
            long projectId,
            long reportSettingsTemplateId);

        Task<ReportSettingsTemplateBase> EditReportSettingsTemplate(
            long projectId,
            long reportSettingsTemplateId,
            IEnumerable<ReportSettingsTemplatePatch> patches);

        Task DeleteReportSettingsTemplate(long projectId, long reportSettingsTemplateId);

        #endregion
    }
}