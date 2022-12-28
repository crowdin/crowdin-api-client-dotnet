
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Workflows
{
    [PublicAPI]
    public class WorkflowTmPreTranslationConfig : WorkflowConfig
    {
        [JsonProperty("minRelevant")]
        public string MinRelevant { get; set; }
        
        [JsonProperty("autoSubstitution")]
        public int AutoSubstitution { get; set; }
    }
}