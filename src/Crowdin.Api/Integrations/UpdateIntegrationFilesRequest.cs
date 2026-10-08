#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Integrations
{
    [PublicAPI]
    public class UpdateIntegrationFilesRequest
    {
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("files")]
        public JObject Files { get; set; } = new JObject();
    }
}