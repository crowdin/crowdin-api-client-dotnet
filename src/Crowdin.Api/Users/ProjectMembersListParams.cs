
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

        public ProjectMembersListParams()
        {
            
        }

        public ProjectMembersListParams(string? search, UserRole? role, string? languageId, int limit, int offset)
        {
            Search = search;
            Role = role;
            LanguageId = languageId;
            Limit = limit;
            Offset = offset;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("search", Search);
            queryParams.AddDescriptionEnumValueIfPresent("role", Role);
            queryParams.AddParamIfPresent("languageId", LanguageId);

            return queryParams;
        }
    }
}