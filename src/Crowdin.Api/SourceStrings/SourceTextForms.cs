
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public class SourceTextForms
    {
        [JsonProperty("one")]
        public string? One { get; set; }
        
        [JsonProperty("two")]
        public string? Two { get; set; }
        
        [JsonProperty("few")]
        public string? Few { get; set; }
        
        [JsonProperty("many")]
        public string? Many { get; set; }
        
        [JsonProperty("other")]
        public string? Other { get; set; }
    }
}