
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class Directory
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }
        
        [JsonProperty("branchId")]
        public long BranchId { get; set; }
        
        [JsonProperty("directoryId")]
        public long DirectoryId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("exportPattern")]
        public string ExportPattern { get; set; }
        
        [JsonProperty("priority")]
        public Priority Priority { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}