
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.Issues
{
    [PublicAPI]
    public interface IIssuesApiExecutor
    {
        Task<ResponseList<Issue>> ListReportedIssues(
            long projectId,
            int limit = 25,
            int offset = 0,
            IssueType? type = null,
            IssueStatus? status = null);

        Task<ResponseList<Issue>> ListReportedIssues(long projectId, IssuesListParams @params);

        Task<Issue> EditIssue(long projectId, long issueId, IEnumerable<IssuePatch> patches);
    }
}