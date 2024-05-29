
using System.Collections.Generic;
using System.ComponentModel;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class EnterpriseProjectPatch : ProjectPatch
    {
        [JsonProperty("path")]
        public EnterpriseProjectPath Path { get; set; }
    }

    [PublicAPI]
    [CallToStringForSerialization]
    public class EnterpriseProjectPath
    {
        public EnterpriseProjectPathCode Code { get; set; }

        public ICollection<string> SubCodes { get; set; } = new List<string>();

        public EnterpriseProjectPath()
        {
            
        }
        
        public EnterpriseProjectPath(EnterpriseProjectPathCode code)
        {
            Code = code;
        }

        public EnterpriseProjectPath(EnterpriseProjectPathCode code, params string[] subCodes)
        {
            Code = code;
            SubCodes = subCodes;
        }

        public static implicit operator EnterpriseProjectPath(EnterpriseProjectPathCode code)
        {
            return new EnterpriseProjectPath(code);
        }

        public override string ToString()
        {
            return SubCodes.Count > 0
                ? $"{Code.ToDescriptionString()}/{string.Join("/", SubCodes)}"
                : Code.ToDescriptionString();
        }
    }

    [PublicAPI]
    public enum EnterpriseProjectPathCode
    {
        [SerializedValue("/groupId")]
        GroupId,
        
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/targetLanguageIds")]
        TargetLanguageIds,
        
        [SerializedValue("/cname")]
        Cname,
        
        [SerializedValue("/description")]
        Description,
        
        [SerializedValue("/translateDuplicates")]
        TranslateDuplicates,
        
        [SerializedValue("/isMtAllowed")]
        IsMtAllowed,
        
        [SerializedValue("/taskBasedAccessControl")]
        TaskBasedAccessControl,
        
        [SerializedValue("/autoSubstitution")]
        AutoSubstitution,
        
        [SerializedValue("/skipUntranslatedStrings")]
        SkipUntranslatedStrings,
        
        [SerializedValue("/skipUntranslatedFiles")]
        SkipUntranslatedFiles,
        
        [SerializedValue("/exportWithMinApprovalsCount")]
        ExportWithMinApprovalsCount,
        
        [SerializedValue("/exportStringsThatPassedWorkflow")]
        ExportStringsThatPassedWorkflow,
        
        [SerializedValue("/autoTranslateDialects")]
        AutoTranslateDialects,
        
        [SerializedValue("/showTmSuggestionsDialects")]
        ShowTmSuggestionsDialects,
        
        [SerializedValue("/glossaryAccess")]
        GlossaryAccess,

        [SerializedValue("/publicDownloads")]
        PublicDownloads,
        
        [SerializedValue("/hiddenStringsProofreadersAccess")]
        HiddenStringsProofreadersAccess,
        
        [SerializedValue("/normalizePlaceholder")]
        NormalizePlaceholder,
        
        [SerializedValue("/saveMetaInfoInSource")]
        SaveMetaInfoInSource,
        
        [SerializedValue("/inContext")]
        InContext,
        
        [SerializedValue("/inContextProcessHiddenStrings")]
        InContextProcessHiddenStrings,
        
        [SerializedValue("/inContextPseudoLanguageId")]
        InContextPseudoLanguageId,
        
        [SerializedValue("/pseudoLanguageId")]
        PseudoLanguageId,
        
        [SerializedValue("/qaCheckIsActive")]
        QaCheckIsActive,
        
        [SerializedValue("/qaCheckCategories")]
        QaCheckCategories,
        
        // /qaCheckCategories/{category}
        
        [SerializedValue("/qaChecksIgnorableCategories")]
        QaChecksIgnorableCategories,
        
        // /qaChecksIgnorableCategories/{category}
        
        [SerializedValue("/languageMapping")]
        LanguageMapping,
        
        // /languageMapping/{languageId}
        
        // /languageMapping/{languageId}/{mappingKey}
        
        [SerializedValue("/notificationSettings/translatorNewStrings")]
        NotificationsTranslatorNewStrings,
        
        [SerializedValue("/notificationSettings/managerNewStrings")]
        NotificationsManagerNewStrings,
        
        [SerializedValue("/notificationSettings/managerLanguageCompleted")]
        NotificationsManagerLanguageCompleted,
        
        [SerializedValue("/defaultTmId")]
        DefaultTmId,
        
        [SerializedValue("/defaultGlossaryId")]
        DefaultGlossaryId,
        
        [SerializedValue("/assignedGlossaries")]
        AssignedGlossaries,
        
        [SerializedValue("/assignedTms")]
        AssignedTms,
        
        // /assignedTms/{tmId}
        
        [SerializedValue("/tmPenalties")]
        TmPenalties
        
        // /tmPenalties/{penaltyKey}
    }
}