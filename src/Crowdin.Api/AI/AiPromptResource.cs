
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiPromptResource
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("action")]
        public AiPromptAction Action { get; set; }
        
        [JsonProperty("aiProviderId")]
        public int AiProviderId { get; set; }
        
        [JsonProperty("aiModelId")]
        public string AiModelId { get; set; }
        
        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }
        
        [JsonProperty("enabledProjectIds")]
        public int[] EnabledProjectIds { get; set; }
        
        [JsonProperty("config")]
        public AiPromptConfiguration Configuration { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}