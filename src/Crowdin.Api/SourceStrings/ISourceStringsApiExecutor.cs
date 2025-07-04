
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public interface ISourceStringsApiExecutor
    {
        Task<ResponseList<SourceString>> ListStrings(
            long projectId,
            int limit = 25,
            int offset = 0,
            int? denormalizePlaceholders = null,
            string? labelIds = null,
            long? fileId = null,
            long? branchId = null,
            long? directoryId = null,
            long? taskId = null,
            string? croql = null,
            string? filter = null,
            StringScope? scope = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<SourceString>> ListStrings(long projectId, StringsListParams @params);

        Task<SourceString> AddString(long projectId, AddStringRequest request);

        Task<ResponseList<SourceString>> StringBatchOperations(
            long projectId,
            IEnumerable<StringBatchOpPatch> patches);

        Task<SourceString> GetString(long projectId, long stringId, bool denormalizePlaceholders = false);

        Task DeleteString(long projectId, long stringId);

        Task<SourceString> EditString(long projectId, long stringId, IEnumerable<SourceStringPatch> patches);

        Task<StringUploadResponseModel> UploadStringsStatus(long projectId, string uploadId);

        Task<StringUploadResponseModel> UploadStrings(long projectId, UploadStringsRequest request);
    }
}