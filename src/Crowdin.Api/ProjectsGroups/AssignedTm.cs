
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class AssignedTm
    {
        [JsonProperty("priority")]
        public int Priority { get; set; }
    }
}