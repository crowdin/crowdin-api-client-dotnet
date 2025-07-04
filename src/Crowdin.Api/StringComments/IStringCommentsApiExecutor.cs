
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public interface IStringCommentsApiExecutor
    {
        Task ListStringComments(
            long projectId,
            int limit = 25,
            int offset = 0,
            long? stringId = null,
            StringCommentType? type = null,
            ISet<IssueType>? issueTypes = null,
            IssueStatus? issueStatus = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<StringComment>> ListStringComments(
            long projectId,
            StringCommentsListParams @params);

        Task<StringComment> AddStringComment(long projectId, AddStringCommentRequest request);

        Task<ResponseList<StringComment>> StringCommentBatchOperations(
            long projectId,
            IEnumerable<StringCommentBatchOpPatch> patches);

        Task<StringComment> GetStringComment(long projectId, long stringCommentId);

        Task DeleteStringComment(long projectId, long stringCommentId);

        Task<StringComment> EditStringComment(
            long projectId,
            long stringCommentId,
            IEnumerable<StringCommentPatch> patches);
    }
}