
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
        [Description("/groupId")]
        GroupId,
        
        [Description("/name")]
        Name,
        
        [Description("/targetLanguageIds")]
        TargetLanguageIds,
        
        [Description("/cname")]
        Cname,
        
        [Description("/description")]
        Description,
        
        [Description("/translateDuplicates")]
        TranslateDuplicates,
        
        [Description("/isMtAllowed")]
        IsMtAllowed,
        
        [Description("/taskBasedAccessControl")]
        TaskBasedAccessControl,
        
        [Description("/autoSubstitution")]
        AutoSubstitution,
        
        [Description("/skipUntranslatedStrings")]
        SkipUntranslatedStrings,
        
        [Description("/skipUntranslatedFiles")]
        SkipUntranslatedFiles,
        
        [Description("/exportWithMinApprovalsCount")]
        ExportWithMinApprovalsCount,
        
        [Description("/exportStringsThatPassedWorkflow")]
        ExportStringsThatPassedWorkflow,
        
        [Description("/autoTranslateDialects")]
        AutoTranslateDialects,
        
        [Description("/showTmSuggestionsDialects")]
        ShowTmSuggestionsDialects,
        
        [Description("/glossaryAccess")]
        GlossaryAccess,

        [Description("/publicDownloads")]
        PublicDownloads,
        
        [Description("/hiddenStringsProofreadersAccess")]
        HiddenStringsProofreadersAccess,
        
        [Description("/normalizePlaceholder")]
        NormalizePlaceholder,
        
        [Description("/saveMetaInfoInSource")]
        SaveMetaInfoInSource,
        
        [Description("/inContext")]
        InContext,
        
        [Description("/inContextProcessHiddenStrings")]
        InContextProcessHiddenStrings,
        
        [Description("/inContextPseudoLanguageId")]
        InContextPseudoLanguageId,
        
        [Description("/pseudoLanguageId")]
        PseudoLanguageId,
        
        [Description("/qaCheckIsActive")]
        QaCheckIsActive,
        
        [Description("/qaCheckCategories")]
        QaCheckCategories,
        
        // /qaCheckCategories/{category}
        
        [Description("/qaChecksIgnorableCategories")]
        QaChecksIgnorableCategories,
        
        // /qaChecksIgnorableCategories/{category}
        
        [Description("/languageMapping")]
        LanguageMapping,
        
        // /languageMapping/{languageId}
        
        // /languageMapping/{languageId}/{mappingKey}
        
        [Description("/notificationSettings/translatorNewStrings")]
        NotificationsTranslatorNewStrings,
        
        [Description("/notificationSettings/managerNewStrings")]
        NotificationsManagerNewStrings,
        
        [Description("/notificationSettings/managerLanguageCompleted")]
        NotificationsManagerLanguageCompleted,
        
        [Description("/defaultTmId")]
        DefaultTmId,
        
        [Description("/defaultGlossaryId")]
        DefaultGlossaryId,
        
        [Description("/assignedGlossaries")]
        AssignedGlossaries,
        
        [Description("/assignedTms")]
        AssignedTms,
        
        // /assignedTms/{tmId}
        
        [Description("/tmPenalties")]
        TmPenalties
        
        // /tmPenalties/{penaltyKey}
    }
}