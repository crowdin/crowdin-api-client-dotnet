
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class Match
    {
        [JsonProperty("matchType")]
        public MatchType MatchType { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }
    }
}