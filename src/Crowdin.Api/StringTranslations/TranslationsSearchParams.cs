using System.Collections.Generic;

using JetBrains.Annotations;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class TranslationsSearchParams : IQueryParamsProvider
    {
        public string Filter { get; set; } = null!;

        public IEnumerable<long>? ProjectIds { get; set; }

        public long? UserId { get; set; }

        public IEnumerable<string>? LanguageIds { get; set; }

        public int? DenormalizePlaceholders { get; set; }

        public int Limit { get; set; } = 25;

        public int Offset { get; set; }

        public TranslationsSearchParams()
        {
        }

        public TranslationsSearchParams(
            string filter,
            IEnumerable<long>? projectIds = null,
            long? userId = null,
            IEnumerable<string>? languageIds = null,
            int? denormalizePlaceholders = null,
            int limit = 25,
            int offset = 0)
        {
            Filter = filter;
            ProjectIds = projectIds;
            UserId = userId;
            LanguageIds = languageIds;
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
            queryParams.AddParamIfPresent("languageIds", LanguageIds);
            queryParams.AddParamIfPresent("denormalizePlaceholders", DenormalizePlaceholders);

            return queryParams;
        }
    }
}
