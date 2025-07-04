
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ReportIndividualRatesForm
    {
        [JsonProperty("languageIds")]
        public ICollection<string>? LanguageIds { get; set; }
        
        [JsonProperty("userIds")]
        public ICollection<long>? UserIds { get; set; }
        
        [JsonProperty("rates")]
        public ICollection<ReportCreateForm>? Rates { get; set; }
    }
}