
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class EnterpriseProjectMembersListParams : IQueryParamsProvider
    {
        public string? Search { get; set; }
        
        public string? LanguageId { get; set; }
        
        public long? WorkflowStepId { get; set; }

        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }

        public EnterpriseProjectMembersListParams()
        {
            
        }

        public EnterpriseProjectMembersListParams(
            string? search,
            string? languageId,
            long? workflowStepId,
            int limit,
            int offset)
        {
            Search = search;
            LanguageId = languageId;
            WorkflowStepId = workflowStepId;
            Limit = limit;
            Offset = offset;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("search", Search);
            queryParams.AddParamIfPresent("languageId", LanguageId);
            queryParams.AddParamIfPresent("workflowStepId", WorkflowStepId);

            return queryParams;
        }
    }
}