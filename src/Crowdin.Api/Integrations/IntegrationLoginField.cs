#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Integrations
{
    [PublicAPI]
    public class IntegrationLoginField
    {
        [JsonProperty("key")]
        public string Key { get; set; } = null!;

        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }
}