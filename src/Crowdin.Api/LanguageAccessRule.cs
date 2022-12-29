
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api
{
    [PublicAPI]
    public class LanguageAccessRule
    {
        [JsonProperty("allContent")]
        public bool? AllContent { get; set; }
        
        [JsonProperty("workflowStepIds")]
        public object? WorkflowStepIds { get; set; }
    }
}