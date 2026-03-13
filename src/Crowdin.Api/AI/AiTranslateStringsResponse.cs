using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiTranslateStringsResponse
    {
        [JsonProperty("sourceLanguageId")]
        public string SourceLanguageId { get; set; } = null!;

        [JsonProperty("targetLanguageId")]
        public string TargetLanguageId { get; set; } = null!;

        [JsonProperty("translations")]
        public ICollection<string> Translations { get; set; } = null!;
    }
}