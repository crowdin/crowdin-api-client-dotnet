
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ReportApprovalIndividualRates
    {
        [JsonProperty("languageIdsTo")]
        public ICollection<string>? LanguageIdsTo { get; set; }
            
        [JsonProperty("userIds")]
        public ICollection<long>? UserIds { get; set; }
            
        [JsonProperty("rates")]
        public ICollection<ReportApprovalRate>? Rates { get; set; }
    }
}