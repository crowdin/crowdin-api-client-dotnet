
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class EnterpriseUsersListParams : IQueryParamsProvider
    {
        public UserStatus? Status { get; set; }
        
        public string? Search { get; set; }
        
        public UserTwoFactorStatus? TwoFactor { get; set; }

        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }

        public EnterpriseUsersListParams()
        {
            
        }

        public EnterpriseUsersListParams(
            UserStatus? status, string? search,
            UserTwoFactorStatus? twoFactor, int limit, int offset)
        {
            Status = status;
            Search = search;
            TwoFactor = twoFactor;
            Limit = limit;
            Offset = offset;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddDescriptionEnumValueIfPresent("status", Status);
            queryParams.AddParamIfPresent("search", Search);
            queryParams.AddDescriptionEnumValueIfPresent("twoFactor", TwoFactor);

            return queryParams;
        }
    }
}