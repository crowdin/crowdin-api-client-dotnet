using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
    public sealed class GetProjectIssuesParameters
    {
        public IssueType? Type { get; set; }

        public IssueStatus? Status { get; set; }

        public String File { get; set; }

        public String Language { get; set; }

        [Property("date_from")]
        public DateTime? DateFrom { get; set; }

        [Property("date_to")]
        public DateTime? DateTo { get; set; }
    }
}
