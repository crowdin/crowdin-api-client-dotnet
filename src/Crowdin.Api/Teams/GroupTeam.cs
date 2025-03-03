
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public class GroupTeam
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("team")]
        public Team Team { get; set; }
    }
}