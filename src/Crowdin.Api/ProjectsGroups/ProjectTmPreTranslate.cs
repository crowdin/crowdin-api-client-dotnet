#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class ProjectTmPreTranslate
    {
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("autoApproveOption")]
        public string? AutoApproveOption { get; set; }

        [JsonProperty("minimumMatchRatio")]
        public string? MinimumMatchRatio { get; set; }
    }
}
