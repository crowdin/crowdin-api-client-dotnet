
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Issues
{
    [PublicAPI]
    public class IssuesListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }
        
        public IssueType? Type { get; set; }
        
        public IssueStatus? Status { get; set; }

        public IssuesListParams()
        {
            
        }

        public IssuesListParams(int limit, int offset, IssueType? type, IssueStatus? status)
        {
            Limit = limit;
            Offset = offset;
            Type = type;
            Status = status;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddDescriptionEnumValueIfPresent("type", Type);
            queryParams.AddDescriptionEnumValueIfPresent("status", Status);

            return queryParams;
        }
    }
}