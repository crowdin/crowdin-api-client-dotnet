#nullable enable

using System;

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class AdvisorInsightLastAiRun
    {
        [JsonProperty("mode")]
        public AdvisorInsightMode Mode { get; set; }

        [JsonProperty("promptId")]
        public long PromptId { get; set; }

        [JsonProperty("at")]
        public DateTimeOffset At { get; set; }
    }
}
