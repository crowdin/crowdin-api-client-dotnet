
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class TmPriority
    {
        [JsonProperty("priority")]
        public int Priority { get; set; }
        
        [JsonProperty("penalty")]
        public int Penalty { get; set; }
    }
}