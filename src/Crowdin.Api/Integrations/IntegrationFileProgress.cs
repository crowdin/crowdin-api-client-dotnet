#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Integrations
{
    [PublicAPI]
    public class IntegrationFileProgress
    {
        [JsonProperty("languageId")]
        public string LanguageId { get; set; } = null!;

        [JsonProperty("eTag")]
        public string? ETag { get; set; }

        [JsonProperty("words")]
        public IntegrationFileProgressCount Words { get; set; } = null!;

        [JsonProperty("phrases")]
        public IntegrationFileProgressCount Phrases { get; set; } = null!;

        [JsonProperty("translationProgress")]
        public int TranslationProgress { get; set; }

        [JsonProperty("approvalProgress")]
        public int ApprovalProgress { get; set; }
    }
}