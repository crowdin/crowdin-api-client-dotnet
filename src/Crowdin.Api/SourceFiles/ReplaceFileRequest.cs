
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class ReplaceFileRequest : UpdateOrRestoreFileRequest
    {
        [JsonProperty("storageId")]
        public long StorageId { get; set; }
        
        [JsonProperty("updateOption")]
        public FileUpdateOption? UpdateOption { get; set; }
        
        [JsonProperty("importOptions")]
        public FileImportOptions? ImportOptions { get; set; }
        
        [JsonProperty("exportOptions")]
        public FileExportOptions? ExportOptions { get; set; }
        
        [JsonProperty("attachLabelIds")]
        public List<long>? AttachLabelIds { get; set; }
        
        [JsonProperty("detachLabelIds")]
        public List<long>? DetachLabelIds { get; set; }
    }
}