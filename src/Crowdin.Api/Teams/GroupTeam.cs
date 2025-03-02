
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public class GroupTeam
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("user")] // TODO: "user" or "team"? In API Docs "user" used https://support.crowdin.com/developer/enterprise/api/v2/#tag/Teams/operation/api.groups.teams.getMany
        public Team Team { get; set; }
    }
}