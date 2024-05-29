
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
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/type")]
        Type,
        
        [SerializedValue("/credentials")]
        Credentials,
        
        [SerializedValue("/config")]
        Config,
        
        [SerializedValue("/isEnabled")]
        IsEnabled,
        
        [SerializedValue("/useSystemCredentials")]
        UseSystemCredentials
    }
}