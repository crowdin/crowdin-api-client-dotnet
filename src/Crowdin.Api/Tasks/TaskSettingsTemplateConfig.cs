
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskSettingsTemplateConfig
    {
        [JsonProperty("languages")]
        public LanguageReference[] Languages { get; set; }
    }
}