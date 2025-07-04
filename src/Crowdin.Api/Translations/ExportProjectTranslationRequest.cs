
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class ExportProjectTranslationRequest
    {
        [JsonProperty("targetLanguageId")]
#pragma warning disable 8618
        public string TargetLanguageId { get; set; }
#pragma warning restore 8618
        
        [JsonProperty("format")]
        public TranslationFormat? Format { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<long>? LabelIds { get; set; }
        
        [JsonProperty("branchIds")]
        public ICollection<long>? BranchIds { get; set; }
        
        [JsonProperty("directoryIds")]
        public ICollection<long>? DirectoryIds { get; set; }
        
        [JsonProperty("fileIds")]
        public ICollection<long>? FileIds { get; set; }
        
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