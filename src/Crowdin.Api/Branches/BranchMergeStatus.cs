
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Branches
{
    [PublicAPI]
    public class BranchMergeStatus
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("status")]
        public OperationStatus Status { get; set; }
        
        [JsonProperty("progress")]
        public long Progress { get; set; }
        
        [JsonProperty("attributes")]
        public AttributesData Attributes { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
        
        [JsonProperty("startedAt")]
        public DateTimeOffset? StartedAt { get; set; }
        
        [JsonProperty("finishedAt")]
        public DateTimeOffset FinishedAt { get; set; }
        
        [PublicAPI]
        public class AttributesData
        {
            [JsonProperty("sourceBranchId")]
            public long SourceBranchId { get; set; }
            
            [JsonProperty("deleteAfterMerge")]
            public bool DeleteAfterMerge { get; set; }
        }
    }
}