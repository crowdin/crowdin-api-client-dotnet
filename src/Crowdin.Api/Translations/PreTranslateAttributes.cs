
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class PreTranslateAttributes
    {
        [JsonProperty("markAddedTranslationsAsDone")]
        public bool? MarkAddedTranslationsAsDone { get; set; }
        
        [JsonProperty("languageIds")]
        public string[] LanguageIds { get; set; }
        
        [JsonProperty("fileIds")]
        public int[] FileIds { get; set; }
        
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
    }
}