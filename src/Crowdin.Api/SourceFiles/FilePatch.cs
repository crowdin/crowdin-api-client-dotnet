
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class FilePatch : PatchEntry
    {
        [JsonProperty("path")]
        public FilePatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum FilePatchPath
    {
        [Description("/branchId")]
        BranchId,
        
        [Description("/directoryId")]
        DirectoryId,
        
        [Description("/name")]
        Name,
        
        [Description("/title")]
        Title,
        
        [Description("/priority")]
        Priority,
        
        [Description("/importOptions/srxStorageId")]
        SrxStorageId,
        
        [Description("/importOptions/customSegmentation")]
        CustomSegmentation,
        
        [Description("/exportOptions/exportPattern")]
        ExportPattern,
        
        [Description("/exportOptions/escapeQuotes")]
        EscapeQuotes,
        
        [Description("/excludedTargetLanguages")]
        ExcludedTargetLanguages,
        
        [Description("/attachLabelIds")]
        AttachLabelIds,
        
        [Description("/detachLabelIds")]
        DetachLabelIds
    }
}