
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class BranchPatch : PatchEntry
    {
        [JsonProperty("path")]
        public BranchPatchPath Path { get; set; }
        
        [JsonProperty("value")]
        public new string Value { get; set; }
    }

    [PublicAPI]
    public enum BranchPatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/title")]
        Title,
        
        [Description("/exportPattern")]
        ExportPattern,
        
        [Description("/priority")]
        Priority
    }
}