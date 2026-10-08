#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class ProjectAiSettings
    {
        [JsonProperty("preTranslationAiPromptId")]
        [System.Obsolete(MessageTexts.UseAiPreTranslateInstead, false)]
        public long? PreTranslationAiPromptId { get; set; }

        [JsonProperty("editorSuggestionAiPromptId")]
        public long? EditorSuggestionAiPromptId { get; set; }

        [JsonProperty("alignmentActionAiPromptId")]
        public long? AlignmentActionAiPromptId { get; set; }

        [JsonProperty("qaCheckActionAiPromptId")]
        public long? QaCheckActionAiPromptId { get; set; }

        [JsonProperty("contextReviewAiPromptId")]
        public long? ContextReviewAiPromptId { get; set; }
    }
}
