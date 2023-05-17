
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class ConcordanceSearchRequest
    {
        [JsonProperty("sourceLanguageId")]
        public string SourceLanguageId { get; set; }
        
        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; }
        
        [JsonProperty("autoSubstitution")]
        public bool AutoSubstitution { get; set; }
        
        [JsonProperty("minRelevant")]
        public int MinRelevant { get; set; }
        
        [JsonProperty("expression")]
        public string Expression { get; set; }
    }
}