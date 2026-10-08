#nullable enable

using System.Collections.Generic;

using Crowdin.Api.Core;

using JetBrains.Annotations;

namespace Crowdin.Api.Integrations
{
    [PublicAPI]
    public class IntegrationJobsListParams : IQueryParamsProvider
    {
        public long ProjectId { get; set; }

        public int? Limit { get; set; }

        public int? Offset { get; set; }

        public string? JobId { get; set; }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.AddParamIfPresent("projectId", ProjectId);
            queryParams.AddParamIfPresent("limit", Limit);
            queryParams.AddParamIfPresent("offset", Offset);
            queryParams.AddParamIfPresent("jobId", JobId);
            return queryParams;
        }
    }
}
