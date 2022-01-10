
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class ProjectMembersResponse
    {
        [JsonProperty("skipped")]
        public ProjectMember[] Skipped { get; set; }
        
        [JsonProperty("added")]
        public ProjectMember[] Added { get; set; }
        
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}