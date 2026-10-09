#nullable enable

using System.Collections.Generic;

using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.ExternalQaChecks
{
    [PublicAPI]
    public class ExternalQaChecksListParams : IQueryParamsProvider
    {
        public long? ProjectId { get; set; }

        public int Limit { get; set; } = 25;

        public int Offset { get; set; }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(Limit, Offset);
            queryParams.AddParamIfPresent("projectId", ProjectId);
            return queryParams;
        }
    }
}
