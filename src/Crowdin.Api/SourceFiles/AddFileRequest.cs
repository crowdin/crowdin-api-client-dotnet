
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class AddFileRequest
    {
        [JsonProperty("storageId")]
        public int StorageId { get; set; }
        
        [JsonProperty("name")]
#pragma warning disable 8618
        public string Name { get; set; }
#pragma warning restore 8618

        [JsonProperty("branchId")]
        public int? BranchId { get; set; }
        
        [JsonProperty("directoryId")]
        public int? DirectoryId { get; set; }
        
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("type")]
        public ProjectFileType? Type { get; set; }
        
        [JsonProperty("importOptions")]
        public FileImportOptions? ImportOptions { get; set; }
        
        [JsonProperty("exportOptions")]
        public FileExportOptions? ExportOptions { get; set; }
        
        [JsonProperty("excludedTargetLanguages")]
        public List<string>? ExcludedTargetLanguages { get; set; }
        
        [JsonProperty("attachLabelIds")]
        public ICollection<int>? AttachLabelIds { get; set; }
    }
}