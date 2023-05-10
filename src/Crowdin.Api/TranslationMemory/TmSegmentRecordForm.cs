
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TmSegmentRecordForm
    {
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}