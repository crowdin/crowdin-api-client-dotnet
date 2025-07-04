
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public class GroupTeam
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("team")]
        public Team Team { get; set; }
    }
}