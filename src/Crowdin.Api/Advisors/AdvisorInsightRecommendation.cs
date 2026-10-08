#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public class AdvisorInsightRecommendation
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [JsonProperty("primary")]
        public bool Primary { get; set; }

        [JsonProperty("params")]
        public JObject Params { get; set; } = null!;
    }
}
