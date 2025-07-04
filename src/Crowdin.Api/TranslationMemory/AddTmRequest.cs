
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class AddTmRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("groupId")]
        public long? GroupId { get; set; }
    }
}