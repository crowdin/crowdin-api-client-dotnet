using JetBrains.Annotations;
using Newtonsoft.Json;
using System;

#nullable enable

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public class DistributionStringBasedRelease
    {
        [JsonProperty("status")]
        public DistributionReleaseStatus? Status { get; set; }

        [JsonProperty("progress")]
        public int? Progress { get; set; }

        [JsonProperty("currentLanguageId")]
        public string? CurrentLanguageId { get; set; }

        [JsonProperty("currentBranchId")]
        public long? CurrentBranchId { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }
    }
}
