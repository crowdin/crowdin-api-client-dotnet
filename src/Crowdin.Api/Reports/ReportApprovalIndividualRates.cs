
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ReportApprovalIndividualRates
    {
        [JsonProperty("languageIdsTo")]
        public ICollection<string>? LanguageIdsTo { get; set; }
            
        [JsonProperty("userIds")]
        public ICollection<int>? UserIds { get; set; }
            
        [JsonProperty("rates")]
        public ICollection<ReportApprovalRate>? Rates { get; set; }
    }
}