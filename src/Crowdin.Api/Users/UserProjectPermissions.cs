#nullable enable

using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Crowdin.Api.ProjectsGroups;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class UserProjectPermissions
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("roles")]
        public UserProjectRole[] Roles { get; set; } = null!;

        [JsonProperty("project")]
        public Project Project { get; set; } = null!;

        [JsonProperty("teams")]
        public UserProjectPermissionsTeam[] Teams { get; set; } = null!;
    }
}
