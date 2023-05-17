
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class TranslationAlignmentRequest
    {
        [JsonProperty("sourceLanguageId")]
        public string SourceLanguageId { get; set; }
        
        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}