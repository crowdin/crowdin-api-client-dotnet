
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class ExportTmRequest
    {
        [JsonProperty("sourceLanguageId")]
        public string? SourceLanguageId { get; set; }
        
        [JsonProperty("targetLanguageId")]
        public string? TargetLanguageId { get; set; }
        
        [JsonProperty("format")]
        public TmFileFormat? Format { get; set; }
    }
}