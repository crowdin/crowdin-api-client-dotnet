using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class TranslationSearchResource : StringTranslation
    {
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("stringId")]
        public long StringId { get; set; }

        [JsonProperty("languageId")]
        public string LanguageId { get; set; } = null!;

        [JsonProperty("providerId")]
        public long? ProviderId { get; set; }

        [JsonProperty("matchRate")]
        public int? MatchRate { get; set; }

        [JsonProperty("matchType")]
        public string? MatchType { get; set; }

        [JsonProperty("workflowStepId")]
        public long? WorkflowStepId { get; set; }
    }
}
