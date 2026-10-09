
#nullable enable annotations

using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;
using Crowdin.Api.Languages;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class ProjectSettings : Project
    {
        [JsonProperty("clientOrganizationId")]
        public long ClientOrganizationId { get; set; }
        
        [JsonProperty("translateDuplicates")]
        public DupTranslateAction TranslateDuplicates { get; set; }

        [JsonProperty("tagsDetection")]
        public TagsDetectionAction TagsDetection { get; set; }
        
        [JsonProperty("glossaryAccess")]
        [System.Obsolete(MessageTexts.UseGlossaryAccessOptionInstead, false)]
        public bool GlossaryAccess { get; set; }

        [JsonProperty("glossaryAccessOption")]
        public GlossaryAccessOption GlossaryAccessOption { get; set; }
        
        [JsonProperty("isMtAllowed")]
        public bool IsMachineTranslationAllowed { get; set; }
        
        [JsonProperty("taskBasedAccessControl")]
        public bool TaskBasedAccessControl { get; set; }
        
        [JsonProperty("hiddenStringsProofreadersAccess")]
        public bool HiddenStringsProofreadersAccess { get; set; }
        
        [JsonProperty("autoSubstitution")]
        public bool AutoSubstitution { get; set; }
        
        [JsonProperty("showTmSuggestionsDialects")]
        public bool ShowTmSuggestionsDialects { get; set; }
        
        [JsonProperty("exportTranslatedOnly")]
        public bool ExportTranslatedOnly { get; set; }
        
        [JsonProperty("skipUntranslatedStrings")]
        public bool SkipUntranslatedStrings { get; set; }
        
        [JsonProperty("skipUntranslatedFiles")]
        public bool SkipUntranslatedFiles { get; set; }
        
        [JsonProperty("exportApprovedOnly")]
        public bool ExportApprovedOnly { get; set; }
        
        [JsonProperty("autoTranslateDialects")]
        public bool AutoTranslateDialects { get; set; }
        
        [JsonProperty("useGlobalTm")]
        public bool UseGlobalTm { get; set; }
        
        [JsonProperty("tmContextType")]
        public TmContextType TmContextType { get; set; }
        
        [JsonProperty("normalizePlaceholder")]
        public bool NormalizePlaceholder { get; set; }
        
        [JsonProperty("saveMetaInfoInSource")]
        public bool SaveMetaInfoInSource { get; set; }
        
        [JsonProperty("inContext")]
        public bool InContext { get; set; }

        [JsonProperty("inContextProcessHiddenStrings")]
        public string InContextProcessHiddenStrings { get; set; }
        
        [CanBeNull]
        [JsonProperty("inContextPseudoLanguageId")]
        public string InContextPseudoLanguageId { get; set; }
        
        [JsonProperty("inContextPseudoLanguage")]
        public Language InContextPseudoLanguage { get; set; }
        
        [JsonProperty("isSuspended")]
        public bool IsSuspended { get; set; }
        
        [JsonProperty("qaCheckIsActive")]
        public bool QaCheckIsActive { get; set; }
        
        [JsonProperty("qaApprovalsCount")]
        public int QaApprovalsCount { get; set; }
        
        [JsonProperty("qaCheckCategories")]
        public QaCheckCategories QaCheckCategories { get; set; }
        
        [JsonProperty("qaChecksIgnorableCategories")]
        public QaCheckCategories QaChecksIgnorableCategories { get; set; }
        
        [JsonProperty("languageMapping")]
        public IDictionary<string, LanguageMapping> LanguageMappings { get; set; }
        
        [JsonProperty("notificationSettings")]
        public NotificationSettings NotificationSettings { get; set; }
        
        [JsonProperty("defaultTmId")]
        public long DefaultTmId { get; set; }
        
        [JsonProperty("defaultGlossaryId")]
        public long DefaultGlossaryId { get; set; }
        
        [JsonProperty("assignedTms")]
        public IDictionary<long, AssignedTm> AssignedTms { get; set; }
        
        [JsonProperty("assignedGlossaries")]
        public long[] AssignedGlossaries { get; set; }
        
        [JsonProperty("tmPenalties")]
        [JsonConverter(typeof(EmptyArrayAsObjectConverter))]
        public TmPenalties TmPenalties { get; set; }

        [JsonProperty("tmApprovedSuggestionsOnly")]
        public bool? TmApprovedSuggestionsOnly { get; set; }

        [JsonProperty("assignedStyleGuides")]
        public long[]? AssignedStyleGuides { get; set; }

        [JsonProperty("externalQaCheckIds")]
        public long[]? ExternalQaCheckIds { get; set; }

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

        [JsonProperty("fields")]
        public IDictionary<string, object>? Fields { get; set; }
    }
}
