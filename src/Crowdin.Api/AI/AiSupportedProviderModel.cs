using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiSupportedProviderModel
    {
        [JsonProperty("providerId")]
        public long ProviderId { get; set; }

        [JsonProperty("providerType")]
        public string? ProviderType { get; set; }

        [JsonProperty("providerName")]
        public string? ProviderName { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("supportReasoning")]
        public bool SupportReasoning { get; set; }

        [JsonProperty("intelligence")]
        public int Intelligence { get; set; }

        [JsonProperty("speed")]
        public int Speed { get; set; }

        [JsonProperty("price")]
        public AiModelPrice? Price { get; set; }

        [JsonProperty("modalities")]
        public AiModelModalities? Modalities { get; set; }

        [JsonProperty("contextWindow")]
        public long ContextWindow { get; set; }

        [JsonProperty("maxOutputTokens")]
        public long MaxOutputTokens { get; set; }

        [JsonProperty("knowledgeCutoff")]
        public DateTime? KnowledgeCutoff { get; set; }

        [JsonProperty("releaseDate")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("features")]
        public AiModelFeatures? Features { get; set; }
    }
}