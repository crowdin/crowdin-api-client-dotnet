
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Workflows
{
    [PublicAPI]
    public class WorkflowTranslationConfig : WorkflowConfig
    {
        [JsonProperty("assignees")]
        public IDictionary<string, long[]> Assignees { get; set; }
    }
}