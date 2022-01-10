
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Dictionaries
{
    [PublicAPI]
    public class Dictionary
    {
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("words")]
        public string[] Words { get; set; }
    }
}