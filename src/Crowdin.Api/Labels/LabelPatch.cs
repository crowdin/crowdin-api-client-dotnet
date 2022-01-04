
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Labels
{
    [PublicAPI]
    public class LabelPatch : PatchEntry
    {
        [JsonProperty("path")]
        public LabelPatchPath Path { get; set; }
        
        [JsonProperty("value")]
        public new string Value { get; set; }
    }

    [PublicAPI]
    public enum LabelPatchPath
    {
        [Description("/title")]
        Title
    }
}