
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Workflows
{
    [PublicAPI]
    public class WorkflowMtPreTranslationConfig : WorkflowConfig
    {
        [JsonProperty("mtId")]
        public int MtId { get; set; }
    }
}