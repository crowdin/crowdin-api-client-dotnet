
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class DirectoryPatch : PatchEntry
    {
        [JsonProperty("path")]
        public DirectoryPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum DirectoryPatchPath
    {
        [SerializedValue("/branchId")]
        BranchId,
        
        [SerializedValue("/directoryId")]
        DirectoryId,
        
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