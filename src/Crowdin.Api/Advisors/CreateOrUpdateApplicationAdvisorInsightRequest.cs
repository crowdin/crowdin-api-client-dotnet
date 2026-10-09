#nullable enable

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class CreateOrUpdateApplicationAdvisorInsightRequest
    {
        [JsonProperty("outcome")]
        public AdvisorInsightOutcome Outcome { get; set; }

        [JsonProperty("checkedAt")]
        public DateTimeOffset? CheckedAt { get; set; }

        [JsonProperty("metrics")]
        public AdvisorInsightMetric[]? Metrics { get; set; }

        [JsonProperty("recommendations")]
        public AdvisorInsightRecommendation[]? Recommendations { get; set; }

        [JsonProperty("payload")]
        public JObject? Payload { get; set; }
    }
}
