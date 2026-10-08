#nullable enable

using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class AdvisorCheckAttributes
    {
        [JsonProperty("category")]
        public string? Category { get; set; }

        [JsonProperty("inspectors")]
        public ICollection<AdvisorCheckInspector>? Inspectors { get; set; }
    }
}
