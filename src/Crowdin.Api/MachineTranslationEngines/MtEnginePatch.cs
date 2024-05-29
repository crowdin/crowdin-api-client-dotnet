
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public class MtEnginePatch : PatchEntry
    {
        [JsonProperty("path")]
        public MtEnginePatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum MtEnginePatchPath
    {
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/type")]
        Type,
        
        [SerializedValue("/credentials")]
        Credentials
    }
}