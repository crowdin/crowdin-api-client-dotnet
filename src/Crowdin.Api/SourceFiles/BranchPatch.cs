
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
    }

    [PublicAPI]
    public enum BranchPatchPath
    {
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/title")]
        Title,
        
        [SerializedValue("/exportPattern")]
        ExportPattern,
        
        [SerializedValue("/priority")]
        Priority
    }
}