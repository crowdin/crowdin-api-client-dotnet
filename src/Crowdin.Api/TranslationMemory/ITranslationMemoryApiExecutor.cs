
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
            int? userId = null,
            int? groupId = null,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<TranslationMemory>> ListTms(TmsListParams @params);

        Task<TranslationMemory> AddTm(AddTmRequest request);

        Task<TranslationMemory> GetTm(int tmId);

        Task DeleteTm(int tmId);

        Task<TranslationMemory> EditTm(int tmId, IEnumerable<TmPatch> patches);

        Task ClearTm(int tmId);

        Task<TmExportStatus> ExportTm(int tmId, ExportTmRequest request);

        Task<TmExportStatus> CheckTmExportStatus(int tmId, string exportId);

        Task<DownloadLink> DownloadTm(int tmId, string exportId);

        Task<ResponseList<TmConcordanceResultResource>> ConcordanceSearch(
            int projectId,
            ConcordanceSearchRequest request);

        Task<TmImportStatus> ImportTm(int tmId, ImportTmRequest request);

        Task<TmImportStatus> CheckTmImportStatus(int tmId, string importId);

        #region Segments

        Task<ResponseList<TmSegmentResource>> ListTmSegments(
            int tmId,
            int limit = 25,
            int offset = 0,
            IEnumerable<SortingRule>? orderBy = null);

        Task<TmSegmentResource> CreateTmSegment(int tmId, CreateTmSegmentRequest request);

        Task<TmSegmentResource> GetTmSegment(int tmId, int segmentId);

        Task DeleteTmSegment(int tmId, int segmentId);

        Task DeleteTmSegmentRecord(int tmId, int segmentId, int recordId);

        Task<TmSegmentResource> EditTmSegmentRecord(
            int tmId,
            int segmentId,
            int recordId,
            IEnumerable<TmSegmentRecordPatch> patches);

        Task<TmSegmentResource> CreateTmSegmentRecords(
            int tmId,
            int segmentId,
            CreateTmSegmentRecordsRequest request);

        #endregion
    }
}