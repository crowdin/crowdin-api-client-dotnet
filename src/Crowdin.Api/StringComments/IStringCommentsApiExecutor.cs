
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
            int projectId,
            int limit = 25,
            int offset = 0,
            int? stringId = null,
            StringCommentType? type = null,
            ISet<IssueType>? issueTypes = null,
            IssueStatus? issueStatus = null,
            IEnumerable<SortingRule>? orderBy = null);

        Task<ResponseList<StringComment>> ListStringComments(
            int projectId,
            StringCommentsListParams @params);

        Task<StringComment> AddStringComment(int projectId, AddStringCommentRequest request);

        Task<ResponseList<StringComment>> StringCommentBatchOperations(
            int projectId,
            IEnumerable<StringCommentBatchOpPatch> patches);

        Task<StringComment> GetStringComment(int projectId, int stringCommentId);

        Task DeleteStringComment(int projectId, int stringCommentId);

        Task<StringComment> EditStringComment(
            int projectId,
            int stringCommentId,
            IEnumerable<StringCommentPatch> patches);
    }
}