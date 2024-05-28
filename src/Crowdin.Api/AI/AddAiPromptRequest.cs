
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AddAiPromptRequest
    {
#pragma warning disable CS8618
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("action")]
        public AiPromptAction Action { get; set; }
        
        [JsonProperty("aiProviderId")]
        public int AiProviderId { get; set; }
        
        [JsonProperty("aiModelId")]
        public string AiModelId { get; set; }
        
        [JsonProperty("config")]
        public AiPromptConfiguration Configuration { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("isEnabled")]
        public bool? IsEnabled { get; set; }
        
        [JsonProperty("enabledProjectIds")]
        public ICollection<int>? EnabledProjectIds { get; set; }
    }
}