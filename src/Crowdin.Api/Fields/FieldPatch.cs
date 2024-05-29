using System.ComponentModel;
using Crowdin.Api.Dictionaries;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Fields
{
    public class FieldPatch : PatchEntry
    {
        [JsonProperty("path")]
        public FieldPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum FieldPatchPath
    {
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/description")]
        Description,
        
        [SerializedValue("/config")]
        Config,
        
        [SerializedValue("/entities")]
        Entities
    }
}