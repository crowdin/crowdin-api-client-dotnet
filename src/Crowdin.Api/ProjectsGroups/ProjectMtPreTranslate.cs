#nullable enable

using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class ProjectMtPreTranslate
    {
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("mts")]
        public ICollection<ProjectMt>? Mts { get; set; }
    }
}
