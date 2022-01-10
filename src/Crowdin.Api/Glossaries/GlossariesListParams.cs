
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class GlossariesListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }
        
        public int? UserId { get; set; }
        
        public int? GroupId { get; set; }

        public GlossariesListParams()
        {
            
        }

        public GlossariesListParams(int limit, int offset, int? userId, int? groupId)
        {
            Limit = limit;
            Offset = offset;
            UserId = userId;
            GroupId = groupId;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("userId", UserId);
            queryParams.AddParamIfPresent("groupId", GroupId);
            
            return queryParams;
        }
    }
}