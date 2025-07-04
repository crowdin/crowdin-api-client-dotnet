
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Workflows
{
    [PublicAPI]
    public class WorkflowMtPreTranslationConfig : WorkflowConfig
    {
        [JsonProperty("mtId")]
        public long MtId { get; set; }
    }
}