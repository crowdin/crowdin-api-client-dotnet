#nullable enable

using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class AdvisorInsightsListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;

        public int Offset { get; set; }

        public bool? IsDismissed { get; set; }

        public string? Status { get; set; }

        public string? Outcome { get; set; }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(Limit, Offset);
            queryParams.AddParamIfPresent("isDismissed", IsDismissed);
            queryParams.AddParamIfPresent("status", Status);
            queryParams.AddParamIfPresent("outcome", Outcome);
            return queryParams;
        }
    }
}
