#nullable enable

using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Crowdin.Api.ProjectsGroups;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class UserProjectRole
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("permissions")]
        public UserProjectRolePermissions Permissions { get; set; } = null!;
    }
}
