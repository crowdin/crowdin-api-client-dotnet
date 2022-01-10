
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class LanguagePermission
    {
        [JsonProperty("workflowStepIds")]
        public object WorkflowStepIds { get; set; }
    }
}