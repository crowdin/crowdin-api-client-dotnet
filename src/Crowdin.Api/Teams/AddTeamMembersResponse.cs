
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public class AddTeamMembersResponse
    {
        [JsonProperty("skipped")]
        public TeamMember[] Skipped { get; set; }
        
        [JsonProperty("added")]
        public TeamMember[] Added { get; set; }
        
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}