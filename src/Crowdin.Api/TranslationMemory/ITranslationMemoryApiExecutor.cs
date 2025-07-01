
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public interface ITranslationMemoryApiExecutor
    {
        Task<ResponseList<TranslationMemory>> ListTms(
            long? userId = null,
            long? groupId = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<TranslationMemory>> ListTms(TmsListParams @params);

        Task<TranslationMemory> AddTm(AddTmRequest request);

        Task<TranslationMemory> GetTm(long tmId);

        Task DeleteTm(long tmId);

        Task<TranslationMemory> EditTm(long tmId, IEnumerable<TmPatch> patches);

        Task ClearTm(long tmId);

        Task<TmExportStatus> ExportTm(long tmId, ExportTmRequest request);

        Task<TmExportStatus> CheckTmExportStatus(long tmId, string exportId);

        Task<DownloadLink> DownloadTm(long tmId, string exportId);

        Task<ResponseList<TmConcordanceResultResource>> ConcordanceSearch(
            long projectId,
            ConcordanceSearchRequest request);

        Task<TmImportStatus> ImportTm(long tmId, ImportTmRequest request);

        Task<TmImportStatus> CheckTmImportStatus(long tmId, string importId);

        #region Segments

        Task<ResponseList<TmSegmentResource>> ListTmSegments(
            long tmId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<TmSegmentResource> CreateTmSegment(long tmId, CreateTmSegmentRequest request);

        Task<TmSegmentResource> GetTmSegment(long tmId, long segmentId);

        Task DeleteTmSegment(long tmId, long segmentId);

        Task DeleteTmSegmentRecord(long tmId, long segmentId, long recordId);

        Task<TmSegmentResource> EditTmSegmentRecord(
            long tmId,
            long segmentId,
            long recordId,
            IEnumerable<TmSegmentRecordPatch> patches);

        Task<TmSegmentResource> CreateTmSegmentRecords(
            long tmId,
            long segmentId,
            CreateTmSegmentRecordsRequest request);

        #endregion
    }
}