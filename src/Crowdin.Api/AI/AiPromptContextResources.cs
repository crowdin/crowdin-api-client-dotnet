
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public abstract class AiPromptContextResources
    {

    }

    [PublicAPI]
    public class PreTranslateActionAiPromptContextResources : AiPromptContextResources
    {
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("sourceLanguageId")]
        public string? SourceLanguageId { get; set; }

        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; } = null!;

        [JsonProperty("stringIds")]
        public ICollection<long> StringIds { get; set; } = null!;

        [JsonProperty("overridePromptValues")]
        public PreTranslateOverridePromptValues? OverridePromptValues { get; set; }
    }

    [PublicAPI]
    public class QaCheckActionAiPromptContextResources : AiPromptContextResources
    {
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("sourceLanguageId")]
        public string? SourceLanguageId { get; set; }

        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; } = null!;

        [JsonProperty("stringIds")]
        public ICollection<long> StringIds { get; set; } = null!;

        [JsonProperty("overridePromptValues")]
        public QaCheckOverridePromptValues? OverridePromptValues { get; set; }
    }

    [PublicAPI]
    public class AlignmentActionAiPromptContextResources : AiPromptContextResources
    {
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("sourceLanguageId")]
        public string? SourceLanguageId { get; set; }

        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; } = null!;

        [JsonProperty("stringIds")]
        public ICollection<long> StringIds { get; set; } = null!;

        [JsonProperty("overridePromptValues")]
        public AlignmentOverridePromptValues? OverridePromptValues { get; set; }
    }

    [PublicAPI]
    public class CustomActionAiPromptContextResources : AiPromptContextResources
    {
        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("sourceLanguageId")]
        public string? SourceLanguageId { get; set; }

        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; } = null!;

        [JsonProperty("stringIds")]
        public ICollection<long> StringIds { get; set; } = null!;

        [JsonProperty("customInstruction")]
        public string? CustomInstruction { get; set; }

        [JsonProperty("overridePromptValues")]
        public CustomOverridePromptValues? OverridePromptValues { get; set; }
    }
}
