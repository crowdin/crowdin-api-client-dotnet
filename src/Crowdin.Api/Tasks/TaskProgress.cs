
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskProgress
    {
        [JsonProperty("total")]
        public int Total { get; set; }
        
        [JsonProperty("done")]
        public int Done { get; set; }
        
        [JsonProperty("percent")]
        public int Percent { get; set; }
    }
}