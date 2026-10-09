#nullable enable annotations

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiProviderModelResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("provider")]
        public string? Provider { get; set; }

        [JsonProperty("providerName")]
        public string? ProviderName { get; set; }

        [JsonProperty("providerId")]
        public long? ProviderId { get; set; }

        [JsonProperty("contextWindow")]
        public int? ContextWindow { get; set; }

        [JsonProperty("maxOutputTokens")]
        public int? MaxOutputTokens { get; set; }

        [JsonProperty("supportsStreaming")]
        public bool? SupportsStreaming { get; set; }

        [JsonProperty("supportsFunctionCalling")]
        public bool? SupportsFunctionCalling { get; set; }

        [JsonProperty("supportsJsonMode")]
        public bool? SupportsJsonMode { get; set; }

        [JsonProperty("supportsJsonSchema")]
        public bool? SupportsJsonSchema { get; set; }

        [JsonProperty("supportsVision")]
        public bool? SupportsVision { get; set; }

        [JsonProperty("isCompatibleWithAiLimit")]
        public bool? IsCompatibleWithAiLimit { get; set; }
    }
}
