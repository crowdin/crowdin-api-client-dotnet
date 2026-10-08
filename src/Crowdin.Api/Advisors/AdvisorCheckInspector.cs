#nullable enable

using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class AdvisorCheckInspector
    {
        [JsonProperty("key")]
        public string Key { get; set; } = null!;

        [JsonProperty("options")]
        public AdvisorCheckInspectorOptions? Options { get; set; }
    }
}
