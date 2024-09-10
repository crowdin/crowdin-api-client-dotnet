
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class GenerateAiPromptCompletionRequest
    {
        [JsonProperty("resources")]
        public AiPromptContextResources Resources { get; set; } = null!;
        
        [JsonProperty("tools")]
        public ICollection<AiToolObject>? Tools { get; set; }
        
        [JsonProperty("tool_choice")]
        public object? ToolChoice { get; set; }
    }
}