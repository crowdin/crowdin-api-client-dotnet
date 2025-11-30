using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    public class TranslationImportSkipped
    {
        [JsonProperty("translationEqSource")]
        public int TranslationEqSource { get; set; }
        
        [JsonProperty("hiddenStrings")]
        public int HiddenStrings { get; set; }

        [JsonProperty("qaCheck")]
        public int QaCheck { get; set; }
    }
}