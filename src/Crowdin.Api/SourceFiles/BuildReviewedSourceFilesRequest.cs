
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class BuildReviewedSourceFilesRequest
    {
        [JsonProperty("branchId")]
        public long? BranchId { get; set; }
    }
}