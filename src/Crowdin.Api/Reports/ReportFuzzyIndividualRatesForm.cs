
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ReportFuzzyIndividualRatesForm
    {
        [JsonProperty("languageIds")]
        public ICollection<string>? LanguageIds { get; set; }
        
        [JsonProperty("userIds")]
        public ICollection<int>? UserIds { get; set; }
        
        [JsonProperty("rates")]
        public ICollection<ReportFuzzyCreateForm>? Rates { get; set; }
    }
}