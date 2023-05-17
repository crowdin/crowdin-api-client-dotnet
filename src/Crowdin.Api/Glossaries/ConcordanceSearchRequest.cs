
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class ConcordanceSearchRequest
    {
        [JsonProperty("sourceLanguageId")]
        public string SourceLanguageId { get; set; }
        
        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; }
        
        [JsonProperty("expression")]
        public string Expression { get; set; }
    }
}