
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiSettings
    {
        [JsonProperty("assistActionAiPromptId")]
        public long AssistActionAiPromptId { get; set; }
        
        [JsonProperty("showSuggestion")]
        public bool ShowSuggestion { get; set; }
        
        [JsonProperty("shortcuts")]
        public AiSettingsShortcuts[] Shortcuts { get; set; }
    }
}