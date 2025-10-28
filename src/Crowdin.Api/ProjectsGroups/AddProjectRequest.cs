
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class AddProjectRequest
    {
        [JsonProperty("tmApprovedSuggestionsOnly")]
        public bool? TmApprovedSuggestionsOnly { get; set; }
    }
}