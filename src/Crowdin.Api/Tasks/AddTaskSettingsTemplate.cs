
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class AddTaskSettingsTemplate
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("config")]
        public TaskSettingsTemplateConfigForm Config { get; set; }
    }
}