
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Branches
{
    [PublicAPI]
    public class BranchMergeSummary
    {
        [JsonProperty("status")]
        public BranchMergeStatusId Status { get; set; }
        
        [JsonProperty("sourceBranchId")]
        public int SourceBranchId { get; set; }
        
        [JsonProperty("targetBranchId")]
        public int TargetBranchId { get; set; }
        
        [JsonProperty("dryRun")]
        public bool DryRun { get; set; }
        
        [JsonProperty("details")]
        public DetailsData Details { get; set; }
        
        [PublicAPI]
        public class DetailsData
        {
            [JsonProperty("added")]
            public int Added { get; set; }
            
            [JsonProperty("deleted")]
            public int Deleted { get; set; }
            
            [JsonProperty("updated")]
            public int Updated { get; set; }
            
            [JsonProperty("conflicted")]
            public int Conflicted { get; set; }
        }
    }
}