#nullable enable

using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Crowdin.Api.ProjectsGroups;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class UserProjectRolePermissions
    {
        [JsonProperty("allLanguages")]
        public bool AllLanguages { get; set; }

        [JsonProperty("languagesAccess")]
        public IDictionary<string, UserProjectLanguageAccess> LanguagesAccess { get; set; } = null!;
    }
}
