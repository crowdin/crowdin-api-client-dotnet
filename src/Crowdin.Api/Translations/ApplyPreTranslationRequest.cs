
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class ApplyPreTranslationRequest
    {
        [JsonProperty("languageIds")]
        public ICollection<string> LanguageIds { get; set; } = new List<string>();

        [JsonProperty("branchIds")]
        public ICollection<long>? BranchIds { get; set; }

        [JsonProperty("fileIds")]
        public ICollection<long>? FileIds { get; set; }

        [JsonProperty("method")]
        public PreTranslationMethod? Method { get; set; }

        [JsonProperty("engineId")]
        public long? EngineId { get; set; }

        [JsonProperty("aiPromptId")]
        public long? AiPromptId { get; set; }

        [JsonProperty("autoApproveOption")]
        public AutoApproveOption? AutoApproveOption { get; set; }

        [JsonProperty("duplicateTranslations")]
        public bool? DuplicateTranslations { get; set; }

        [JsonProperty("translateUntranslatedOnly")]
        [Obsolete(MessageTexts.DeprecatedProperty)]
        public bool? TranslateUntranslatedOnly { get; set; }

        [JsonProperty("translateWithPerfectMatchOnly")]
        public bool? TranslateWithPerfectMatchOnly { get; set; }

        [JsonProperty("fallbackLanguages")]
        public IDictionary<string, string[]>? FallbackLanguages { get; set; }

        [JsonProperty("labelIds")]
        public ICollection<long> LabelIds { get; set; } = new List<long>();

        [JsonProperty("excludeLabelIds")]
        public ICollection<long> ExcludeLabelIds { get; set; } = new List<long>();

        [JsonProperty("scope")]
        public PreTranslationScope? Scope { get; set; }

        [JsonProperty("translationModifiedBefore")]
        public DateTimeOffset? TranslationModifiedBefore { get; set; }

        [JsonProperty("replaceTranslationsOption")]
        public ReplaceTranslationsOption? ReplaceTranslationsOption { get; set; }

        [JsonProperty("resetApprovalStatus")]
        public bool? ResetApprovalStatus { get; set; }
    }
}