#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Integrations
{
    [PublicAPI]
    public class IntegrationLoginRequest
    {
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("credentials")]
        public JObject Credentials { get; set; } = new JObject();
    }
}