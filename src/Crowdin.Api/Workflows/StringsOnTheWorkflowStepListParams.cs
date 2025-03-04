
using System.Collections.Generic;
using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Workflows
{
    public class StringsOnTheWorkflowStepListParams : IQueryParamsProvider
    {
        public IEnumerable<string>? LanguageIds { get; set; }
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }

        public WorkflowStatus? Status { get; set; }

        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }
        
        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("languageIds", LanguageIds);
            queryParams.AddSortingRulesIfPresent(OrderBy);
            queryParams.AddDescriptionEnumValueIfPresent("status", Status);
            
            return queryParams;
        }
    }
}