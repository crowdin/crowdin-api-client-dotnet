
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Branches
{
    [PublicAPI]
    public class MergeBranchRequest
    {
        [JsonProperty("deleteAfterMerge")]
        public bool? DeleteAfterMerge { get; set; }
        
        [JsonProperty("sourceBranchId")]
        public int SourceBranchId { get; set; }
        
        [JsonProperty("dryRun")]
        public bool? DryRun { get; set; }
    }
}