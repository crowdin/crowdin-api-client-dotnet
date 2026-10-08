#nullable enable

using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Crowdin.Api.ProjectsGroups;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class UserProjectPermissionsTeam
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("totalMembers")]
        public int TotalMembers { get; set; }

        [JsonProperty("webUrl")]
        public string WebUrl { get; set; } = null!;

        [JsonProperty("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public System.DateTimeOffset? UpdatedAt { get; set; }
    }
}
