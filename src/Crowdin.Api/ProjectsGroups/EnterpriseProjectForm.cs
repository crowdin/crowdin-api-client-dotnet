
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class EnterpriseProjectForm : AddProjectRequest
    {
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("sourceLanguageId")]
#pragma warning disable CS8618
        public string SourceLanguageId { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("templateId")]
        public int TemplateId { get; set; }
        
        [JsonProperty("groupId")]
        public int? GroupId { get; set; }
        
        [JsonProperty("targetLanguageIds")]
        public ICollection<string>? TargetLanguageIds { get; set; }
        
        [JsonProperty("vendorId")]
        public int? VendorId { get; set; }
        
        [JsonProperty("mtEngineId")]
        public int? MtEngineId { get; set; }
        
        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("translateDuplicates")]
        public DupTranslateAction? TranslateDuplicates { get; set; }
        
        [JsonProperty("tagsDetection")]
        public TagsDetectionAction? TagsDetection { get; set; }
        
        [JsonProperty("isMtAllowed")]
        public bool? IsMtAllowed { get; set; }
        
        [JsonProperty("autoSubstitution")]
        public bool? AutoSubstitution { get; set; }
        
        [JsonProperty("autoTranslateDialects")]
        public bool? AutoTranslateDialects { get; set; }
        
        [JsonProperty("publicDownloads")]
        public bool? PublicDownloads { get; set; }
        
        [JsonProperty("hiddenStringsProofreadersAccess")]
        public bool? HiddenStringsProofreadersAccess { get; set; }
        
        [JsonProperty("useGlobalTm")]
        public bool? UseGlobalTm { get; set; }
        
        [JsonProperty("delayedWorkflowStart")]
        public bool? DelayedWorkflowStart { get; set; }
        
        [JsonProperty("skipUntranslatedStrings")]
        public bool? SkipUntranslatedStrings { get; set; }
        
        [JsonProperty("skipUntranslatedFiles")]
        public bool? SkipUntranslatedFiles { get; set; }
        
        [JsonProperty("exportWithMinApprovalsCount")]
        public int? ExportWithMinApprovalsCount { get; set; }
        
        [JsonProperty("normalizePlaceholder")]
        public bool? NormalizePlaceholder { get; set; }
        
        [JsonProperty("saveMetaInfoInSource")]
        public bool? SaveMetaInfoInSource { get; set; }
        
        [JsonProperty("inContext")]
        public bool? InContext { get; set; }

        [JsonProperty("inContextProcessHiddenStrings")]
        public bool? InContextProcessHiddenStrings { get; set; }
        
        [JsonProperty("inContextPseudoLanguageId")]
        public string? InContextPseudoLanguageId { get; set; }
        
        [JsonProperty("qaCheckIsActive")]
        public bool? QaCheckIsActive { get; set; }
        
        [JsonProperty("qaCheckCategories")]
        public QaCheckCategories? QaCheckCategories { get; set; }
        
        [JsonProperty("customQaCheckIds")]
        public ICollection<int>? CustomQaCheckIds { get; set; }
        
        [JsonProperty("languageMapping")]
        public IDictionary<string, LanguageMapping>? LanguageMapping { get; set; }
        
        [JsonProperty("glossaryAccess")]
        public bool? GlossaryAccess { get; set; }
        
        [JsonProperty("notificationSettings")]
        public NotificationSettings? NotificationSettings { get; set; }
    }
}