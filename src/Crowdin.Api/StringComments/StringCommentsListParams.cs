
using System.Collections.Generic;
using System.Linq;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public class StringCommentsListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }
        
        public int? StringId { get; set; }
        
        public StringCommentType? Type { get; set; }

        public ISet<IssueType> IssueTypes { get; set; } = new HashSet<IssueType>();
        
        public IssueStatus? IssueStatus { get; set; }

        public StringCommentsListParams()
        {
            
        }

        public StringCommentsListParams(
            int limit, int offset, int? stringId,
            StringCommentType? type, ISet<IssueType>? issueTypes, IssueStatus? issueStatus)
        {
            Limit = limit;
            Offset = offset;
            StringId = stringId;
            Type = type;
            IssueTypes = issueTypes ?? new HashSet<IssueType>();
            IssueStatus = issueStatus;
        }


        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("stringId", StringId);
            queryParams.AddDescriptionEnumValueIfPresent("type", Type);
            
            if (IssueTypes.Count > 0)
            {
                queryParams.AddParamIfPresent("issueType",
                    string.Join(",", IssueTypes.Select(type => type.ToDescriptionString())));
            }
            
            queryParams.AddDescriptionEnumValueIfPresent("issueStatus", IssueStatus);
            
            return queryParams;
        }
    }
}