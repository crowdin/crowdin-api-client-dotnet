
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class TranslationApprovalsListParams : IQueryParamsProvider
    {
        public int? FileId { get; set; }

        public string? LabelIds { get; set; }
        
        public string? ExcludeLabelIds { get; set; }
        
        public int? StringId { get; set; }
        
        public string? LanguageId { get; set; }
        
        public int? TranslationId { get; set; }
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }

        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }

        public TranslationApprovalsListParams()
        {
            
        }

        public TranslationApprovalsListParams(
            int? fileId,
            string? labelIds,
            string? excludeLabelIds,
            int? stringId,
            string? languageId,
            int? translationId,
            IEnumerable<SortingRule>? orderBy,
            int limit,
            int offset)
        {
            FileId = fileId;
            LabelIds = labelIds;
            ExcludeLabelIds = excludeLabelIds;
            StringId = stringId;
            LanguageId = languageId;
            TranslationId = translationId;
            OrderBy = orderBy;
            Limit = limit;
            Offset = offset;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("fileId", FileId);
            queryParams.AddParamIfPresent("labelIds", LabelIds);
            queryParams.AddParamIfPresent("excludeLabelIds", ExcludeLabelIds);
            queryParams.AddParamIfPresent("stringId", StringId);
            queryParams.AddParamIfPresent("languageId", LanguageId);
            queryParams.AddParamIfPresent("translationId", TranslationId);
            queryParams.AddSortingRulesIfPresent(OrderBy);

            return queryParams;
        }
    }
}