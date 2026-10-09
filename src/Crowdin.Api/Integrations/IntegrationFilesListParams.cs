#nullable enable

using System.Collections.Generic;

using Crowdin.Api.Core;

using JetBrains.Annotations;

namespace Crowdin.Api.Integrations
{
    [PublicAPI]
    public class IntegrationFilesListParams : IQueryParamsProvider
    {
        public long ProjectId { get; set; }

        public long? FileId { get; set; }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.AddParamIfPresent("projectId", ProjectId);
            queryParams.AddParamIfPresent("fileId", FileId);
            return queryParams;
        }
    }
}
