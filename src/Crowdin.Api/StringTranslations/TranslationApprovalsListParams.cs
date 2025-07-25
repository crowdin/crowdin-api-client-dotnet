﻿
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class TranslationApprovalsListParams : IQueryParamsProvider
    {
        public long? FileId { get; set; }

        public string? LabelIds { get; set; }
        
        public string? ExcludeLabelIds { get; set; }
        
        public long? StringId { get; set; }
        
        public string? LanguageId { get; set; }
        
        public long? TranslationId { get; set; }

        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }
        
        public IEnumerable<SortingRule>? OrderBy { get; set; }

        public TranslationApprovalsListParams()
        {
            
        }

        public TranslationApprovalsListParams(
            long? fileId,
            string? labelIds,
            string? excludeLabelIds,
            long? stringId,
            string? languageId,
            long? translationId,
            int limit,
            int offset,
            IEnumerable<SortingRule>? orderBy = null)
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