
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class Alignment
    {
        [JsonProperty("sourceWord")]
        public string SourceWord { get; set; }
        
        [JsonProperty("sourceLemma")]
        public string SourceLemma { get; set; }
        
        [JsonProperty("targetWord")]
        public string TargetWord { get; set; }
        
        [JsonProperty("targetLemma")]
        public string TargetLemma { get; set; }
        
        [JsonProperty("match")]
        public int Match { get; set; }
        
        [JsonProperty("probability")]
        public float Probability { get; set; }
    }
}