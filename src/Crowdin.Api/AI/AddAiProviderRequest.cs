
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AddAiProviderRequest
    {
#pragma warning disable CS8618
        [JsonProperty("name")]
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("type")]
        public AiProviderType Type { get; set; }
        
        [JsonProperty("credentials")]
        public AiProviderCredentials? Credentials { get; set; }
        
        [JsonProperty("config")]
        public AiProviderConfiguration? Configuration { get; set; }
        
        [JsonProperty("isEnabled")]
        public bool? IsEnabled { get; set; }
        
        [JsonProperty("useSystemCredentials")]
        public bool? UseSystemCredentials { get; set; }
    }
}