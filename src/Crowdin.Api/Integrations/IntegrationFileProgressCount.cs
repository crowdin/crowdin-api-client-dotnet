#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Integrations
{
    [PublicAPI]
    public class IntegrationFileProgressCount
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("translated")]
        public int Translated { get; set; }

        [JsonProperty("approved")]
        public int Approved { get; set; }
    }
}