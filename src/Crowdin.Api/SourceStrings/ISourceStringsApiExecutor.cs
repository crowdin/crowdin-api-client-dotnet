
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
            int projectId,
            int limit = 25,
            int offset = 0,
            int? denormalizePlaceholders = null,
            string? labelIds = null,
            int? fileId = null,
            int? branchId = null,
            int? directoryId = null,
            int? taskId = null,
            string? croql = null,
            string? filter = null,
            StringScope? scope = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<SourceString>> ListStrings(int projectId, StringsListParams @params);

        Task<SourceString> AddString(int projectId, AddStringRequest request);

        Task<ResponseList<SourceString>> StringBatchOperations(
            int projectId,
            IEnumerable<StringBatchOpPatch> patches);

        Task<SourceString> GetString(int projectId, int stringId, bool denormalizePlaceholders = false);

        Task DeleteString(int projectId, int stringId);

        Task<SourceString> EditString(int projectId, int stringId, IEnumerable<SourceStringPatch> patches);

        Task<StringUploadResponseModel> UploadStringsStatus(int projectId, string uploadId);

        Task<StringUploadResponseModel> UploadStrings(int projectId, UploadStringsRequest request);
    }
}