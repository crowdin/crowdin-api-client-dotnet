
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public class AddTeamMembersRequest
    {
        [JsonProperty("userIds")]
        public ICollection<int> UserIds { get; set; }
    }
}