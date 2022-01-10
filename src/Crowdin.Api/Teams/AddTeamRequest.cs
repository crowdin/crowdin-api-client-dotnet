
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public class AddTeamRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}