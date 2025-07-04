
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class PreTranslateAttributes
    {        
        [JsonProperty("languageIds")]
        public string[] LanguageIds { get; set; } = Array.Empty<string>();
        
        [JsonProperty("branchIds")]
        public string[] BranchIds { get; set; } = Array.Empty<string>();
        
        [JsonProperty("fileIds")]
        public long[]? FileIds { get; set; }
        
        [JsonProperty("method")]
        public PreTranslationMethod Method { get; set; }
        
        [JsonProperty("autoApproveOption")]
        public AutoApproveOption AutoApproveOption { get; set; }
        
        [JsonProperty("duplicateTranslations")]
        public bool DuplicateTranslations { get; set; }
        
        [JsonProperty("skipApprovedTranslations")]
        public bool SkipApprovedTranslations { get; set; }
        
        [JsonProperty("translateUntranslatedOnly")]
        public bool TranslateUntranslatedOnly { get; set; }
        
        [JsonProperty("translateWithPerfectMatchOnly")]
        public bool TranslateWithPerfectMatchOnly { get; set; }
        
        [JsonProperty("labelIds")]
        public long[] LabelIds { get; set; }

        [JsonProperty("excludeLabelIds")]
        public long[] ExcludeLabelIds { get; set; }
    }
}