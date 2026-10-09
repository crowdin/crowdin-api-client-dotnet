#nullable enable

using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class AdvisorInsightMetric
    {
        [JsonProperty("key")]
        public string Key { get; set; } = null!;

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("unit")]
        public AdvisorInsightMetricUnit Unit { get; set; }

        [JsonProperty("threshold")]
        public double? Threshold { get; set; }

        [JsonProperty("tone")]
        public AdvisorInsightMetricTone Tone { get; set; }

        [JsonProperty("source")]
        public AdvisorInsightMetricSource? Source { get; set; }

        [JsonProperty("checkedAt")]
        public DateTimeOffset? CheckedAt { get; set; }
    }
}
