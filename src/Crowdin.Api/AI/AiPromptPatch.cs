
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
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/action")]
        Action,
        
        [SerializedValue("/aiProviderId")]
        AiProviderId,
        
        [SerializedValue("/aiModelId")]
        AiModelId,
        
        [SerializedValue("/isEnabled")]
        IsEnabled,
        
        [SerializedValue("/enabledProjectIds")]
        EnabledProjectIds,
        
        [SerializedValue("/config")]
        Config
    }
}