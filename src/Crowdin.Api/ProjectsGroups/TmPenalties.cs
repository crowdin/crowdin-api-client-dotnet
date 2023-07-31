
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class TmPenalties
    {
        [JsonProperty("autoSubstitution")]
        public int AutoSubstitution { get; set; }
        
        [JsonProperty("tmPriority")]
        public TmPriority TmPriority { get; set; }
        
        [JsonProperty("multipleTranslations")]
        public int MultipleTranslations { get; set; }
        
        [JsonProperty("timeSinceLastUsage")]
        public TmTimeElapsed TimeSinceLastUsage { get; set; }
        
        [JsonProperty("timeSinceLastModified")]
        public TmTimeElapsed TimeSinceLastModified { get; set; }
    }
}