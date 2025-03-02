
using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Teams;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class GroupManager
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("user")]
        public UserEnterprise User { get; set; }
        
        [JsonProperty("teams")]
        public Team[] Teams { get; set; }
    }
}