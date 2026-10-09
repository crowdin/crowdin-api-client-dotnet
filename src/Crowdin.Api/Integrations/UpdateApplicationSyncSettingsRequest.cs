#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Integrations
{
    [PublicAPI]
    public class UpdateApplicationSyncSettingsRequest
    {
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; } = null!;

        [JsonProperty("files")]
        public JToken Files { get; set; } = new JObject();
    }
}