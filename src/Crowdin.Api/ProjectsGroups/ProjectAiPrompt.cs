#nullable enable

using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class ProjectAiPrompt
    {
        [JsonProperty("aiPromptId")]
        public long? AiPromptId { get; set; }

        [JsonProperty("languageIds")]
        public ICollection<string>? LanguageIds { get; set; }
    }
}
