
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class TmTimeElapsed
    {
        [JsonProperty("months")]
        public int Months { get; set; }
        
        [JsonProperty("penalty")]
        public int Penalty { get; set; }
    }
}