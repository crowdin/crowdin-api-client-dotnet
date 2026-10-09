
using System.Collections.Generic;
using Crowdin.Api.Core;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class FileBasedProjectForm : ProjectForm
    {
        [JsonProperty("normalizePlaceholder")]
        public bool? NormalizePlaceholder { get; set; }
        
        [JsonProperty("saveMetaInfoInSource")]
        public bool? SaveMetaInfoInSource { get; set; }
        
        [JsonProperty("notificationSettings")]
        public NotificationSettings? NotificationSettings { get; set; }
        
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("identifier")]
        public string? Identifier { get; set; }
        
        [JsonProperty("sourceLanguageId")]
#pragma warning disable CS8618
        public string SourceLanguageId { get; set; }
#pragma warning restore CS8618
            
        [JsonProperty("targetLanguageIds")]
        public ICollection<string>? TargetLanguageIds { get; set; }
        
        [JsonProperty("visibility")]
        public ProjectVisibility? Visibility { get; set; }
        
        [JsonProperty("languageAccessPolicy")]
        public LanguageAccessPolicy? LanguageAccessPolicy { get; set; }

        [JsonProperty("cname")]
        public string? Cname { get; set; }
        
        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("translateDuplicates")]
        public DupTranslateAction? TranslateDuplicates { get; set; }

        [JsonProperty("tagsDetection")]
        public TagsDetectionAction? TagsDetection { get; set; }
        
        [JsonProperty("isMtAllowed")]
        public bool? IsMtAllowed { get; set; }
        
        [JsonProperty("taskBasedAccessControl")]
        public bool? TaskBasedAccessControl { get; set; }
        
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
        
        [JsonProperty("skipUntranslatedStrings")]
        public bool? SkipUntranslatedStrings { get; set; }
        
        [JsonProperty("skipUntranslatedFiles")]
        public bool? SkipUntranslatedFiles { get; set; }
        
        [JsonProperty("exportApprovedOnly")]
        public bool? ExportApprovedOnly { get; set; }
        
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
        
        [JsonProperty("qaChecksIgnorableCategories")]
        public QaCheckCategories? QaChecksIgnorableCategories { get; set; }
        
        [JsonProperty("languageMapping")]
        public IDictionary<string, LanguageMapping>? LanguageMapping { get; set; }
        
        [JsonProperty("glossaryAccess")]
        [System.Obsolete(MessageTexts.UseGlossaryAccessOptionInstead, false)]
        public bool? GlossaryAccess { get; set; }

        [JsonProperty("glossaryAccessOption")]
        public GlossaryAccessOption? GlossaryAccessOption { get; set; }
        
        [JsonProperty("tmContextType")]
        public TmContextType? TmContextType { get; set; }
        
        [JsonProperty("defaultTmId")]
        public long? DefaultTmId { get; set; }
        
        [JsonProperty("defaultGlossaryId")]
        public long? DefaultGlossaryId { get; set; }

        [JsonProperty("tmApprovedSuggestionsOnly")]
        public bool? TmApprovedSuggestionsOnly { get; set; }

        [JsonProperty("assignedStyleGuides")]
        public ICollection<long>? AssignedStyleGuides { get; set; }

        [JsonProperty("savingsReportSettingsTemplateId")]
        public long? SavingsReportSettingsTemplateId { get; set; }

        [JsonProperty("preTranslationAiPromptId")]
        [System.Obsolete(MessageTexts.UseAiPreTranslateInstead, false)]
        public long? PreTranslationAiPromptId { get; set; }

        [JsonProperty("editorSuggestionAiPromptId")]
        public long? EditorSuggestionAiPromptId { get; set; }

        [JsonProperty("alignmentActionAiPromptId")]
        public long? AlignmentActionAiPromptId { get; set; }

        [JsonProperty("qaCheckActionAiPromptId")]
        public long? QaCheckActionAiPromptId { get; set; }

        [JsonProperty("contextReviewAiPromptId")]
        public long? ContextReviewAiPromptId { get; set; }

        [JsonProperty("aiPreTranslate")]
        public ProjectAiPreTranslate? AiPreTranslate { get; set; }

        [JsonProperty("mtPreTranslate")]
        public ProjectMtPreTranslate? MtPreTranslate { get; set; }

        [JsonProperty("tmPreTranslate")]
        public ProjectTmPreTranslate? TmPreTranslate { get; set; }
    }
}
