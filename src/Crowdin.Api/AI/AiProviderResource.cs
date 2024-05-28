
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiProviderResource
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
#pragma warning disable CS8618
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("type")]
        public AiProviderType Type { get; set; }
        
        [JsonProperty("config")]
        public AiProviderConfiguration Config { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("credentials")]
        public AiProviderCredentials? Credentials { get; set; }
        
        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }
        
        [JsonProperty("useSystemCredentials")]
        public bool UseSystemCredentials { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}