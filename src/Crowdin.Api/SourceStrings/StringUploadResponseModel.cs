
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Crowdin.Api.SourceFiles;

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public class StringUploadResponseModel
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("status")]
        public OperationStatus Status { get; set; }
        
        [JsonProperty("progress")]
        public int Progress { get; set; }
        
        [JsonProperty("attributes")]
        public AttributesData Attributes { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
        
        [JsonProperty("startedAt")]
        public DateTimeOffset? StartedAt { get; set; }
        
        [JsonProperty("finishedAt")]
        public DateTimeOffset? FinishedAt { get; set; }
        
        [PublicAPI]
        public class AttributesData
        {
            [JsonProperty("branchId")]
            public long BranchId { get; set; }
            
            [JsonProperty("storageId")]
            public long StorageId { get; set; }
            
            [JsonProperty("fileType")]
            public string FileType { get; set; }
            
            [JsonProperty("parserVersion")]
            public int ParserVersion { get; set; }
            
            [JsonProperty("labelIds")]
            public int[] LabelIds { get; set; }
            
            [JsonProperty("importOptions")]
            public SpreadsheetFileImportOptions ImportOptions { get; set; }
            
            [JsonProperty("updateStrings")]
            public bool UpdateStrings { get; set; }
            
            [JsonProperty("cleanupMode")]
            public bool CleanupMode { get; set; }
            
            [JsonProperty("updateOption")]
            public UpdateOption UpdateOption { get; set; }
        }
    }
}