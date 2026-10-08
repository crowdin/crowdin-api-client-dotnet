#nullable enable

using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class CreateAdvisorCheckRequest
    {
        [JsonProperty("category")]
        public string? Category { get; set; }

        [JsonProperty("inspectors")]
        public ICollection<AdvisorCheckInspector>? Inspectors { get; set; }
    }
}
