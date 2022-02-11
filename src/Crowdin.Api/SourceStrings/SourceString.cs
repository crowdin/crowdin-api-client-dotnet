
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public class SourceString
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        
        [JsonProperty("fileId")]
        public int FileId { get; set; }
        
        [JsonProperty("branchId")]
        public int? BranchId { get; set; }
        
        [JsonProperty("directoryId")]
        public int? DirectoryId { get; set; }
        
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("context")]
        public string Context { get; set; }
        
        [JsonProperty("maxLength")]
        public int MaxLength { get; set; }
        
        [JsonProperty("isHidden")]
        public bool IsHidden { get; set; }
        
        [JsonProperty("isDuplicate")]
        public bool IsDuplicate { get; set; }
        
        [JsonProperty("masterStringId")]
        public int? MasterStringId { get; set; }
        
        [JsonProperty("revision")]
        public int Revision { get; set; }
        
        [JsonProperty("hasPlurals")]
        public bool HasPlurals { get; set; }
        
        [JsonProperty("isIcu")]
        public bool IsIcu { get; set; }
        
        [JsonProperty("labelIds")]
        public int[] LabelIds { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}