using System.Collections.Generic;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class FilesSearchParams : IQueryParamsProvider
    {
        public string Filter { get; set; } = null!;

        public IEnumerable<long>? ProjectIds { get; set; }

        public long? UserId { get; set; }

        public int Limit { get; set; } = 25;

        public int Offset { get; set; }

        public FilesSearchParams()
        {
        }

        public FilesSearchParams(
            string filter,
            IEnumerable<long>? projectIds = null,
            long? userId = null,
            int limit = 25,
            int offset = 0)
        {
            Filter = filter;
            ProjectIds = projectIds;
            UserId = userId;
            Limit = limit;
            Offset = offset;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(Limit, Offset);

            queryParams.AddParamIfPresent("filter", Filter);
            queryParams.AddParamIfPresent("projectIds", ProjectIds);
            queryParams.AddParamIfPresent("userId", UserId);

            return queryParams;
        }
    }
}
