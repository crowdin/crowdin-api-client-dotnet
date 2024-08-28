
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class ProjectMembersListParams : IQueryParamsProvider
    {
        public string? Search { get; set; }
        
        public UserRole? Role { get; set; }
        
        public string? LanguageId { get; set; }

        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }

        public ProjectMembersListParams()
        {
            
        }

        public ProjectMembersListParams(
            string? search,
            UserRole? role,
            string? languageId,
            int limit,
            int offset,
            IEnumerable<SortingRule>? orderBy = null)
        {
            Search = search;
            Role = role;
            LanguageId = languageId;
            Limit = limit;
            Offset = offset;
            OrderBy = orderBy;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("search", Search);
            queryParams.AddDescriptionEnumValueIfPresent("role", Role);
            queryParams.AddParamIfPresent("languageId", LanguageId);
            queryParams.AddSortingRulesIfPresent(OrderBy);

            return queryParams;
        }
    }
}