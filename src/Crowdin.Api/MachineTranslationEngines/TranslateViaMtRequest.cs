
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public class TranslateViaMtRequest
    {
        [JsonProperty("languageRecognitionProvider")]
        public LanguageRecognitionProvider? LanguageRecognitionProvider { get; set; }
        
        [JsonProperty("sourceLanguageId")]
        public string? SourceLanguageId { get; set; }
        
        [JsonProperty("targetLanguageId")]
#pragma warning disable CS8618
        public string TargetLanguageId { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("strings")]
        public ICollection<string>? Strings { get; set; }
    }
}