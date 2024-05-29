
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public class SourceStringPatch : PatchEntry
    {
        [JsonProperty("path")]
        public StringPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum StringPatchPath
    {
        [SerializedValue("/text")]
        Text,
        
        [SerializedValue("/context")]
        Context,
        
        [SerializedValue("/isHidden")]
        IsHidden,
        
        [SerializedValue("/maxLength")]
        MaxLength,
        
        [SerializedValue("/labelIds")]
        LabelIds
    }
}