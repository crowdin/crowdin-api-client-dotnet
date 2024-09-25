
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiSettingsPatch : PatchEntry
    {
        [JsonProperty("path")]
        public AiSettingsPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum AiSettingsPatchPath
    {
        [Description("/assistActionAiPromptId")]
        AssistActionAiPromptId,
        
        [Description("/shortcuts")]
        Shortcuts,
        
        [Description("/showSuggestion")]
        ShowSuggestion
    }
}