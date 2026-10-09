#nullable enable

using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Integrations
{
    [PublicAPI]
    public class IntegrationJob
    {
        [JsonProperty("jobId")]
        public string? JobId { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; } = new Dictionary<string, JToken>();
    }
}
