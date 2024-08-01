
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TmsListParams : IQueryParamsProvider
    {
        public int? UserId { get; set; }
        
        public int? GroupId { get; set; }
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }

        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }

        public TmsListParams()
        {
            
        }

        public TmsListParams(
            int? userId,
            int? groupId,
            IEnumerable<SortingRule>? orderBy,
            int limit,
            int offset)
        {
            UserId = userId;
            GroupId = groupId;
            OrderBy = orderBy;
            Limit = limit;
            Offset = offset;
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