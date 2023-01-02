
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskSettingsTemplateConfigForm
    {
        [JsonProperty("languages")]
        public ICollection<LanguageReference> Languages { get; set; }
    }
}