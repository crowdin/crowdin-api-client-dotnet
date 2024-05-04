
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiPromptPatch : PatchEntry
    {
        [JsonProperty("path")]
        public AiPromptPatchPath Path { get; set; }
    }
    
    [PublicAPI]
    public enum AiPromptPatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/action")]
        Action,
        
        [Description("/aiProviderId")]
        AiProviderId,
        
        [Description("/aiModelId")]
        AiModelId,
        
        [Description("/isEnabled")]
        IsEnabled,
        
        [Description("/enabledProjectIds")]
        EnabledProjectIds,
        
        [Description("/config")]
        Config
    }
}