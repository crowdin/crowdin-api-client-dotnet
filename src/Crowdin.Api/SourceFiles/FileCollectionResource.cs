
using System;
using Newtonsoft.Json;

namespace Crowdin.Api.SourceFiles
{
    public class FileCollectionResource : FileInfoCollectionResource
    {
        [JsonProperty("revisionId")]
        public long RevisionId { get; set; }
        
        [JsonProperty("priority")]
        public Priority Priority { get; set; }
        
        [JsonProperty("importOptions")]
        public FileImportOptions ImportOptions { get; set; }
        
        [JsonProperty("exportOptions")]
        public FileExportOptions ExportOptions { get; set; }
        
        [JsonProperty("excludedTargetLanguages")]
        public string[] ExcludedTargetLanguages { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}