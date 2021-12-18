
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class File
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        
        [JsonProperty("branchId")]
        public int? BranchId { get; set; }
        
        [JsonProperty("directoryId")]
        public int? DirectoryId { get; set; }
        
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("title")]
        public string? Title { get; set; }
        
        [JsonProperty("type")]
#pragma warning disable CS8618
        public string Type { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("path")]
#pragma warning disable CS8618
        public string Path { get; set; }
#pragma warning restore CS8618
            
        [JsonProperty("status")]
        public FileStatus Status { get; set; }
        
        [JsonProperty("revisionId")]
        public int RevisionId { get; set; }
        
        [JsonProperty("priority")]
        public Priority Priority { get; set; }
        
        [JsonProperty("importOptions")]
        public FileImportOptions? ImportOptions { get; set; }
        
        [JsonProperty("exportOptions")]
        public FileExportOptions? ExportOptions { get; set; }
        
        [JsonProperty("excludedTargetLanguages")]
        public string[]? ExcludedTargetLanguages { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}