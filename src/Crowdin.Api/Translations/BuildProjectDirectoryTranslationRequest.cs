
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class BuildProjectDirectoryTranslationRequest
    {
        [JsonProperty("targetLanguageIds")]
        public ICollection<string> TargetLanguagesIds { get; set; } = new List<string>();
        
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