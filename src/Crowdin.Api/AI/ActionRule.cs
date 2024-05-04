
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class ActionRule
    {
        [JsonProperty("action")]
        public AiPromptAction? Action { get; set; }
        
        [JsonProperty("availableAiModelIds")]
        public List<string> AvailableAiModelIds { get; set; }
    }
}