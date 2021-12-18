
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public class QaCheckResource
    {
        [JsonProperty("stringId")]
        public int StringId { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("category")]
        public QaCheckIssueCategory Category { get; set; }
        
        [JsonProperty("categoryDescription")]
        public string CategoryDescription { get; set; }
        
        [JsonProperty("validation")]
        public QaCheckIssueValidationType Validation { get; set; }
        
        [JsonProperty("validationDescription")]
        public string ValidationDescription { get; set; }
        
        [JsonProperty("pluralId")]
        public int PluralId { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}