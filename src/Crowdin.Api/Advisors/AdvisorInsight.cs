#nullable enable

using System;

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class AdvisorInsight
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("inspectorKey")]
        public string InspectorKey { get; set; } = null!;

        [JsonProperty("category")]
        public string? Category { get; set; }

        [JsonProperty("isDismissed")]
        public bool IsDismissed { get; set; }

        [JsonProperty("status")]
        public AdvisorInsightStatus Status { get; set; }

        [JsonProperty("outcome")]
        public AdvisorInsightOutcome? Outcome { get; set; }

        [JsonProperty("severity")]
        public AdvisorInsightSeverity? Severity { get; set; }

        [JsonProperty("refreshPolicy")]
        public AdvisorInsightRefreshPolicy? RefreshPolicy { get; set; }

        [JsonProperty("metrics")]
        public AdvisorInsightMetric[]? Metrics { get; set; }

        [JsonProperty("recommendations")]
        public AdvisorInsightRecommendation[]? Recommendations { get; set; }

        [JsonProperty("checkedAt")]
        public DateTimeOffset? CheckedAt { get; set; }

        [JsonProperty("lastAiRun")]
        public AdvisorInsightLastAiRun? LastAiRun { get; set; }

        [JsonProperty("payload")]
        public JObject? Payload { get; set; }
    }
}
