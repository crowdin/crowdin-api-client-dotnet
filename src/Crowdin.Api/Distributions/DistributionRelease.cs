
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public class DistributionRelease
    {
        [JsonProperty("status")]
        public DistributionReleaseStatus? Status { get; set; }
        
        [JsonProperty("progress")]
        public int? Progress { get; set; }
        
        [JsonProperty("currentLanguageId")]
        public string? CurrentLanguageId { get; set; }
        
        [JsonProperty("currentFileId")]
        public long? CurrentFileId { get; set; }
        
        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }
    }
}