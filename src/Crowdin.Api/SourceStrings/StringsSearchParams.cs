using System.Collections.Generic;
using System.ComponentModel;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public class StringsSearchParams : IQueryParamsProvider
    {
        public string Filter { get; set; } = null!;

        public IEnumerable<long>? ProjectIds { get; set; }

        public long? UserId { get; set; }

        public StringSearchScope? Scope { get; set; }

        public int? DenormalizePlaceholders { get; set; }

        public int Limit { get; set; } = 25;

        public int Offset { get; set; }

        public StringsSearchParams()
        {
        }

        public StringsSearchParams(
            string filter,
            IEnumerable<long>? projectIds = null,
            long? userId = null,
            StringSearchScope? scope = null,
            int? denormalizePlaceholders = null,
            int limit = 25,
            int offset = 0)
        {
            Filter = filter;
            ProjectIds = projectIds;
            UserId = userId;
            Scope = scope;
            DenormalizePlaceholders = denormalizePlaceholders;
            Limit = limit;
            Offset = offset;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(Limit, Offset);

            queryParams.AddParamIfPresent("filter", Filter);
            queryParams.AddParamIfPresent("projectIds", ProjectIds);
            queryParams.AddParamIfPresent("userId", UserId);
            queryParams.AddDescriptionEnumValueIfPresent("scope", Scope);
            queryParams.AddParamIfPresent("denormalizePlaceholders", DenormalizePlaceholders);

            return queryParams;
        }
    }

    [PublicAPI]
    public enum StringSearchScope
    {
        [Description("all")]
        All,

        [Description("text")]
        Text,

        [Description("context")]
        Context,

        [Description("key")]
        Key
    }
}
