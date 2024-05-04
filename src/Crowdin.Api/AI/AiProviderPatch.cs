
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiProviderPatch : PatchEntry
    {
        [JsonProperty("path")]
        public AiProviderPatchPath Path { get; set; }
    }
    
    [PublicAPI]
    public enum AiProviderPatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/type")]
        Type,
        
        [Description("/credentials")]
        Credentials,
        
        [Description("/config")]
        Config,
        
        [Description("/isEnabled")]
        IsEnabled,
        
        [Description("/useSystemCredentials")]
        UseSystemCredentials
    }
}