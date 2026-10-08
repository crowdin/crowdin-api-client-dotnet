#nullable enable

using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class ProjectAiPreTranslate
    {
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("aiPrompts")]
        public ICollection<ProjectAiPrompt>? AiPrompts { get; set; }
    }
}
