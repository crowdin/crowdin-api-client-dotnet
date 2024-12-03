
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Issues;

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IIssuesApiExecutor
    {
        Task<ResponseList<Issue>> ListReportedIssues(
            int projectId,
            int limit = 25,
            int offset = 0,
            IssueType? type = null,
            IssueStatus? status = null);

        Task<ResponseList<Issue>> ListReportedIssues(int projectId, IssuesListParams @params);

        Task<Issue> EditIssue(int projectId, int issueId, IEnumerable<IssuePatch> patches);
    }
}