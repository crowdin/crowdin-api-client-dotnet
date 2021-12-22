
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
        [Description("/text")]
        Text,
        
        [Description("/context")]
        Context,
        
        [Description("/isHidden")]
        IsHidden,
        
        [Description("/maxLength")]
        MaxLength,
        
        [Description("/labelIds")]
        LabelIds
    }
}