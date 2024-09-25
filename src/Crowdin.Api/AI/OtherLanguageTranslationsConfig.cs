
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class OtherLanguageTranslationsConfig
    {
        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }
            
        [JsonProperty("languageIds")]
        public string[] LanguageIds { get; set; }
    }
}