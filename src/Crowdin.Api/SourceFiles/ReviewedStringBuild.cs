
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class ReviewedStringBuild
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }
        
        [JsonProperty("status")]
        public BuildStatus Status { get; set; }
        
        [JsonProperty("progress")]
        public int Progress { get; set; }
        
        [JsonProperty("attributes")]
        public AttributesHolder Attributes { get; set; }

        public class AttributesHolder
        {
            [JsonProperty("branchId")]
            public long BranchId { get; set; }
            
            [JsonProperty("targetLanguageId")]
            public string TargetLanguageId { get; set; }
        }
    }
}