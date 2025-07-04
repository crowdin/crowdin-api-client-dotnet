
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class AddTranslationRequest
    {
        [JsonProperty("stringId")]
        public long StringId { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("pluralCategoryName")]
        public PluralCategoryName? PluralCategoryName { get; set; }
        
        [JsonProperty("addToTm")]
        public bool? AddToTm { get; set; }
    }
}