
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class TranslationAlignment
    {
        [JsonProperty("words")]
        public WordAlignment[] Words { get; set; }
    }
}