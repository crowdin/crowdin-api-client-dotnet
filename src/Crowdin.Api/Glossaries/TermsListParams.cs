
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
        
        public long? UserId { get; set; }
        
        public string? LanguageId { get; set; }
        
        public long? TranslationOfTermId { get; set; }
        
        public long? ConceptId { get; set; }
        
        // ReSharper disable once InconsistentNaming
        public string? CroQL { get; set; }
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }

        public TermsListParams()
        {
            
        }

        public TermsListParams(
            int limit,
            int offset,
            long? userId,
            string? languageId,
            long? translationOfTermId,
            long? conceptId,
            string? croql,
            IEnumerable<SortingRule>? orderBy)
        {
            Limit = limit;
            Offset = offset;
            UserId = userId;
            LanguageId = languageId;
            TranslationOfTermId = translationOfTermId;
            ConceptId = conceptId;
            CroQL = croql;
            OrderBy = orderBy;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("userId", UserId);
            queryParams.AddParamIfPresent("languageId", LanguageId);
            queryParams.AddParamIfPresent("translationOfTermId", TranslationOfTermId);
            queryParams.AddParamIfPresent("conceptId", ConceptId);
            queryParams.AddParamIfPresent("croql", CroQL);
            queryParams.AddSortingRulesIfPresent(OrderBy);

            return queryParams;
        }
    }
}