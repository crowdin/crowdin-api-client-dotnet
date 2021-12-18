
using System.Collections.Generic;
using Crowdin.Api.Languages;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class ProjectSettings : Project
    {
        [JsonProperty("translateDuplicates")]
        public DupTranslateAction TranslateDuplicates { get; set; }

        [JsonProperty("tagsDetection")]
        public TagsDetectionAction TagsDetection { get; set; }
        
        [JsonProperty("glossaryAccess")]
        public bool GlossaryAccess { get; set; }
        
        [JsonProperty("isMtAllowed")]
        public bool IsMachineTranslationAllowed { get; set; }
        
        [JsonProperty("hiddenStringsProofreadersAccess")]
        public bool HiddenStringsProofreadersAccess { get; set; }
        
        [JsonProperty("autoSubstitution")]
        public bool AutoSubstitution { get; set; }
        
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
        public bool UseGlobalMachineTranslator { get; set; }
        
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
        public bool QaCheckIsActive { get; set; } = true;
        
        [JsonProperty("qaCheckCategories")]
        public QaCheckCategories QaCheckCategories { get; set; }
        
        [JsonProperty("languageMapping")]
        public IDictionary<string, LanguageMapping> LanguageMappings { get; set; }
        
        [JsonProperty("notificationSettings")]
        public NotificationSettings NotificationSettings { get; set; }
    }
}