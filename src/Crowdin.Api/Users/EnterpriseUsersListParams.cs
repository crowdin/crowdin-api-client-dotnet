
using System;
using System.Collections.Generic;
using JetBrains.Annotations;

using Crowdin.Api.Core;
using Crowdin.Api.ProjectsGroups;

#nullable enable

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class EnterpriseUsersListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }
        
        public string? Search { get; set; }
        
        public long? TeamId { get; set; }
        
        public UserStatus? Status { get; set; }
        
        public UserTwoFactorStatus? TwoFactor { get; set; }
        
        public IEnumerable<long>? GroupIds { get; set; }
        
        public IEnumerable<long>? ProjectIds { get; set; }
        
        public IEnumerable<string>? LanguageIds { get; set; }
        
        public IEnumerable<ProjectRole>? ProjectRoles { get; set; }
        
        public IEnumerable<OrganizationRole>? OrganizationRoles { get; set; }
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }
        
        public DateTimeOffset? LastSeenFrom { get; set; }
        
        public DateTimeOffset? LastSeenTo { get; set; }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("search", Search);
            queryParams.AddParamIfPresent("teamId", TeamId);
            
            queryParams.AddDescriptionEnumValueIfPresent("status", Status);
            queryParams.AddDescriptionEnumValueIfPresent("twoFactor", TwoFactor);
            
            queryParams.AddParamIfPresent("groupIds", GroupIds);
            queryParams.AddParamIfPresent("projectIds", ProjectIds);
            queryParams.AddParamIfPresent("languageIds", LanguageIds);
            queryParams.AddParamIfPresent("lastSeenFrom", LastSeenFrom);
            queryParams.AddParamIfPresent("lastSeenTo", LastSeenTo);
            
            queryParams.AddDescriptionEnumValueCollectionIfPresent("projectRoles", ProjectRoles);
            queryParams.AddDescriptionEnumValueCollectionIfPresent("organizationRoles", OrganizationRoles);
            queryParams.AddSortingRulesIfPresent(OrderBy);
            
            return queryParams;
        }
    }
}