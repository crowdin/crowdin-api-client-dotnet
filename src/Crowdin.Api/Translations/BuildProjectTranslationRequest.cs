
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class BuildProjectTranslationRequest
    {
        
    }

    [PublicAPI]
    public class TranslationCreateProjectBuildForm : BuildProjectTranslationRequest
    {
        [JsonProperty("branchId")]
        public int? BranchId { get; set; }
        
        [JsonProperty("targetLanguageIds")]
        public ICollection<string>? TargetLanguageIds { get; set; }
        
        [JsonProperty("skipUntranslatedStrings")]
        public bool? SkipUntranslatedStrings { get; set; }
        
        [JsonProperty("skipUntranslatedFiles")]
        public bool? SkipUntranslatedFiles { get; set; }
        
        [JsonProperty("exportApprovedOnly")]
        public bool? ExportApprovedOnly { get; set; }
    }

    [PublicAPI]
    public class TranslationCreateProjectPseudoBuildForm : BuildProjectTranslationRequest
    {
        [JsonProperty("pseudo")]
        public bool Pseudo { get; set; }
        
        [JsonProperty("branchId")]
        public int? BranchId { get; set; }
        
        [JsonProperty("prefix")]
        public string? Prefix { get; set; }
        
        [JsonProperty("suffix")]
        public string? Suffix { get; set; }
        
        [JsonProperty("lengthTransformation")]
        public int? LengthTransformation { get; set; }
        
        [JsonProperty("charTransformation")]
        public CharTransformationMode? CharTransformation { get; set; }
    }

    [PublicAPI]
    public class EnterpriseTranslationCreateProjectBuildForm : BuildProjectTranslationRequest
    {
        [JsonProperty("branchId")]
        public int? BranchId { get; set; }
        
        [JsonProperty("targetLanguageIds")]
        public ICollection<string>? TargetLanguageIds { get; set; }
        
        [JsonProperty("skipUntranslatedStrings")]
        public bool? SkipUntranslatedStrings { get; set; }
        
        [JsonProperty("skipUntranslatedFiles")]
        public bool? SkipUntranslatedFiles { get; set; }
        
        [JsonProperty("exportWithMinApprovalsCount")]
        public int? ExportWithMinApprovalsCount { get; set; }
    }
}