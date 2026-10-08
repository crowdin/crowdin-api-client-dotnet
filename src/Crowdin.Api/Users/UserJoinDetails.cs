#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class UserJoinDetails
    {
        [JsonProperty("type")]
        public string Type { get; set; } = null!;

        [JsonProperty("invitedBy")]
        public JObject? InvitedBy { get; set; }
    }
}
