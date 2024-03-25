
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class ApplyPreTranslationRequest
    {
        [JsonProperty("languageIds")]
        public ICollection<string> LanguageIds { get; set; } = new List<string>();

        [JsonProperty("fileIds")]
        public ICollection<int> FileIds { get; set; } = new List<int>();
        
        [JsonProperty("method")]
        public PreTranslationMethod? Method { get; set; }
        
        [JsonProperty("engineId")]
        public int? EngineId { get; set; }
        
        [JsonProperty("autoApproveOption")]
        public AutoApproveOption? AutoApproveOption { get; set; }
        
        [JsonProperty("duplicateTranslations")]
        public bool? DuplicateTranslations { get; set; }
        
        [JsonProperty("translateUntranslatedOnly")]
        public bool? TranslateUntranslatedOnly { get; set; }
        
        [JsonProperty("translateWithPerfectMatchOnly")]
        public bool? TranslateWithPerfectMatchOnly { get; set; }

        [JsonProperty("fallbackLanguages")]
        public IDictionary<string, string[]>? FallbackLanguages { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<int> LabelIds { get; set; } = new List<int>();

        [JsonProperty("excludeLabelIds")]
        public ICollection<int> ExcludeLabelIds { get; set; } = new List<int>();

    }
}