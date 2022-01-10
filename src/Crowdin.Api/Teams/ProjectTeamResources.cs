
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public class ProjectTeamResources
    {
        [JsonProperty("skipped")]
        public ProjectTeamResource? Skipped { get; set; }
        
        [JsonProperty("added")]
        public ProjectTeamResource? Added { get; set; }
    }
}