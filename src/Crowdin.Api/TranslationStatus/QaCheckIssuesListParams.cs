
using System.Collections.Generic;
using System.Linq;
using Crowdin.Api.Core;
using JetBrains.Annotations;

#nullable enable

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public class QaCheckIssuesListParams : IQueryParamsProvider
    {
        public int Limit { get; set; } = 25;

        public int Offset { get; set; } = 0;
        
        public ICollection<QaCheckIssueCategory>? Categories { get; set; }
        
        public ICollection<QaCheckIssueValidationType>? Validation { get; set; }
        
        public ICollection<string>? LanguageIds { get; set; }

        public QaCheckIssuesListParams()
        {
            
        }

        public QaCheckIssuesListParams(
            int limit, int offset,
            ICollection<QaCheckIssueCategory>? categories = null,
            ICollection<QaCheckIssueValidationType>? validation = null,
            ICollection<string>? languageIds = null)
        {
            Limit = limit;
            Offset = offset;
            Categories = categories;
            Validation = validation;
            LanguageIds = languageIds;
        }

        public IDictionary<string, string> ToQueryParams()
        {
            IDictionary<string, string> queryParams =
                Utils.CreateQueryParamsFromPaging(Limit, Offset);

            if (Categories != null && Categories.Count > 0)
            {
                queryParams.Add("category",
                    string.Join(",", Categories
                        .Select(category => category.ToDescriptionString())));
            }

            if (Validation != null && Validation.Count > 0)
            {
                queryParams.Add("validation",
                    string.Join(",", Validation
                        .Select(validation => validation.ToDescriptionString())));
            }

            if (LanguageIds != null && LanguageIds.Count > 0)
            {
                queryParams.Add("languageIds", string.Join(",", LanguageIds));
            }

            return queryParams;
        }
    }
}