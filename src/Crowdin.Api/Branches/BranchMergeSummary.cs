
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
        public long SourceBranchId { get; set; }
        
        [JsonProperty("targetBranchId")]
        public long TargetBranchId { get; set; }
        
        [JsonProperty("dryRun")]
        public bool DryRun { get; set; }
        
        [JsonProperty("details")]
        public DetailsData Details { get; set; }
        
        [PublicAPI]
        public class DetailsData
        {
            [JsonProperty("added")]
            public long Added { get; set; }
            
            [JsonProperty("deleted")]
            public long Deleted { get; set; }
            
            [JsonProperty("updated")]
            public long Updated { get; set; }
            
            [JsonProperty("conflicted")]
            public long Conflicted { get; set; }
        }
    }
}