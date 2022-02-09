
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public class MtTranslation
    {
        [JsonProperty("sourceLanguageId")]
        public string SourceLanguageId { get; set; }
        
        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; }
        
        [JsonProperty("strings")]
        public string[] Strings { get; set; }
        
        [JsonProperty("translations")]
        public string[] Translations { get; set; }
    }
}