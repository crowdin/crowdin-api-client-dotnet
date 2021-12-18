
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class BuildProjectFileTranslationRequest
    {
        [JsonProperty("targetLanguageId")]
#pragma warning disable 8618
        public string TargetLanguageId { get; set; }
#pragma warning restore 8618
        
        [JsonProperty("exportAsXliff")]
        public bool? ExportAsXliff { get; set; }
        
        [JsonProperty("skipUntranslatedStrings")]
        public bool? SkipUntranslatedStrings { get; set; }
        
        [JsonProperty("skipUntranslatedFiles")]
        public bool? SkipUntranslatedFiles { get; set; }
        
        // only regular API
        [JsonProperty("exportApprovedOnly")]
        public bool? ExportApprovedOnly { get; set; }
        
        // only enterprise API
        [JsonProperty("exportWithMinApprovalsCount")]
        public int? ExportWithMinApprovalsCount { get; set; }
    }
}