
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class LanguageTranslationsListParams : IQueryParamsProvider
    {
        public string? StringIds { get; set; }
        
        public string? LabelIds { get; set; }
        
        public int? FileId { get; set; }
        
        // ReSharper disable once InconsistentNaming
        public string? CroQL { get; set; }
        
        public bool? DenormalizePlaceholders { get; set; }

        public int Limit { get; set; } = 25;
        
        public int Offset { get; set; }

        public LanguageTranslationsListParams()
        {
            
        }

        public LanguageTranslationsListParams(
            string? stringIds,
            string? labelIds,
            int? fileId,
            string? croQl,
            bool? denormalizePlaceholders,
            int limit, int offset)
        {
            StringIds = stringIds;
            LabelIds = labelIds;
            FileId = fileId;
            CroQL = croQl;
            DenormalizePlaceholders = denormalizePlaceholders;
            Limit = limit;
            Offset = offset;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);
            
            queryParams.AddParamIfPresent("stringIds", StringIds);
            queryParams.AddParamIfPresent("labelIds", LabelIds);
            queryParams.AddParamIfPresent("fileId", FileId);
            queryParams.AddParamIfPresent("croql", CroQL);

            if (DenormalizePlaceholders.HasValue && DenormalizePlaceholders.Value)
            {
                queryParams.Add("denormalizePlaceholders", "1");
            }

            return queryParams;
        }
    }
}