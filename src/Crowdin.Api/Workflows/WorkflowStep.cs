
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Workflows
{
    [PublicAPI]
    public class WorkflowStep
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("type")]
        public WorkflowStepType Type { get; set; }
        
        [JsonProperty("languages")]
        public string[] Languages { get; set; }
        
        [JsonProperty("config")]
        public object Config { get; set; }
    }
}