
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
        [Description("/branchId")]
        BranchId,
        
        [Description("/directoryId")]
        DirectoryId,
        
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