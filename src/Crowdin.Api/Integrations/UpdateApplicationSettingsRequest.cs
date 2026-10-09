#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Integrations
{
    [PublicAPI]
    public class UpdateApplicationSettingsRequest
    {
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("config")]
        public JObject Config { get; set; } = new JObject();
    }
}