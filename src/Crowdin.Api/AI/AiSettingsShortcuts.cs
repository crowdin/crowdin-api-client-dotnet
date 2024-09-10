
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiSettingsShortcuts
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("prompt")]
        public string Prompt { get; set; }
        
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}