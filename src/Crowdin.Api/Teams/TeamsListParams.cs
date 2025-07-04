
using System.Collections.Generic;
using JetBrains.Annotations;

using Crowdin.Api.Core;
using Crowdin.Api.ProjectsGroups;

#nullable enable

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public class TeamsListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;

        public int Offset { get; set; }
        
        public string? Search { get; set; }
        
        public IEnumerable<long>? GroupIds { get; set; }
        
        public IEnumerable<long>? ProjectIds { get; set; }
        
        public IEnumerable<string>? LanguageIds { get; set; }
        
        public IEnumerable<ProjectRole>? ProjectRoles { get; set; }
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }
        
        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("search", Search);
            
            queryParams.AddParamIfPresent("groupIds", GroupIds);
            queryParams.AddParamIfPresent("projectIds", ProjectIds);
            queryParams.AddParamIfPresent("languageIds", LanguageIds);
            
            queryParams.AddDescriptionEnumValueCollectionIfPresent("projectRoles", ProjectRoles);
            queryParams.AddSortingRulesIfPresent(OrderBy);
            
            return queryParams;
        }
    }
}