
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class StringTranslationsListParams : IQueryParamsProvider
    {
        public int StringId { get; set; }
        
        public string LanguageId { get; set; }
        
        public bool? DenormalizePlaceholders { get; set; }

        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }

        public StringTranslationsListParams()
        {
            
        }

        public StringTranslationsListParams(
            int stringId, string languageId,
            bool? denormalizePlaceholders,
            int limit, int offset)
        {
            StringId = stringId;
            LanguageId = languageId;
            DenormalizePlaceholders = denormalizePlaceholders;
            Limit = limit;
            Offset = offset;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("stringId", StringId);
            queryParams.AddParamIfPresent("languageId", LanguageId);

            if (DenormalizePlaceholders.HasValue && DenormalizePlaceholders.Value)
            {
                queryParams.Add("denormalizePlaceholders", "1");
            }

            return queryParams;
        }
    }
}