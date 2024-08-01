
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class GlossariesListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }
        
        public int? UserId { get; set; }
        
        public int? GroupId { get; set; }
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }

        public GlossariesListParams()
        {
            
        }

        public GlossariesListParams(
            int limit,
            int offset,
            int? userId,
            int? groupId,
            IEnumerable<SortingRule>? orderBy)
        {
            Limit = limit;
            Offset = offset;
            UserId = userId;
            GroupId = groupId;
            OrderBy = orderBy;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("userId", UserId);
            queryParams.AddParamIfPresent("groupId", GroupId);
            queryParams.AddSortingRulesIfPresent(OrderBy);
            
            return queryParams;
        }
    }
}