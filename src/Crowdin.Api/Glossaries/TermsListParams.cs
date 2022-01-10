
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class TermsListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }
        
        public int? UserId { get; set; }
        
        public string? LanguageId { get; set; }
        
        public int? TranslationOfTermId { get; set; }

        public TermsListParams()
        {
            
        }

        public TermsListParams(
            int limit, int offset, int? userId,
            string? languageId, int? translationOfTermId)
        {
            Limit = limit;
            Offset = offset;
            UserId = userId;
            LanguageId = languageId;
            TranslationOfTermId = translationOfTermId;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("userId", UserId);
            queryParams.AddParamIfPresent("languageId", LanguageId);
            queryParams.AddParamIfPresent("translationOfTermId", TranslationOfTermId);

            return queryParams;
        }
    }
}