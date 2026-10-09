#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;
using Crowdin.Api.ProjectsGroups;
using Crowdin.Api.Users;

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public class TeamProjectPermissions
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("roles")]
        public UserProjectRole[] Roles { get; set; } = null!;

        [JsonProperty("project")]
        public Project Project { get; set; } = null!;
    }
}
