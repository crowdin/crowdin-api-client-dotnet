#nullable enable

using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class AdvisorCheckInspectorOptions
    {
        [JsonProperty("mode")]
        public AdvisorInsightMode? Mode { get; set; }

        [JsonProperty("promptId")]
        public long? PromptId { get; set; }
    }
}
