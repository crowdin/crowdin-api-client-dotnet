
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public class ProgressResourceStatus
    {
        [JsonProperty("total")]
        public int Total { get; set; }
            
        [JsonProperty("translated")]
        public int Translated { get; set; }

        [JsonProperty("preTranslateAppliedTo")]
        public int PreTranslateAppliedTo { get; set; }
            
        [JsonProperty("approved")]
        public int Approved { get; set; }
    }
}