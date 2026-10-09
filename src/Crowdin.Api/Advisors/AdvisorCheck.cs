#nullable enable

using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class AdvisorCheck
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; } = null!;

        [JsonProperty("status")]
        public AdvisorCheckStatus Status { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("attributes")]
        public AdvisorCheckAttributes Attributes { get; set; } = null!;

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("startedAt")]
        public DateTimeOffset? StartedAt { get; set; }

        [JsonProperty("finishedAt")]
        public DateTimeOffset? FinishedAt { get; set; }
    }
}
