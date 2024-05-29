
using System.Collections.Generic;
using System.ComponentModel;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class ProjectInfoPatch : ProjectPatch
    {
        [JsonProperty("path")]
        public ProjectInfoPath Path { get; set; }
    }

    [PublicAPI]
    [CallToStringForSerialization]
    public class ProjectInfoPath
    {
        public ProjectInfoPathCode Code { get; set; }

        public ICollection<string> SubCodes { get; set; } = new List<string>();

        public ProjectInfoPath()
        {
            
        }
        
        public ProjectInfoPath(ProjectInfoPathCode code)
        {
            Code = code;
        }

        public ProjectInfoPath(ProjectInfoPathCode code, params string[] subCodes)
        {
            Code = code;
            SubCodes = subCodes;
        }

        public static implicit operator ProjectInfoPath(ProjectInfoPathCode code)
        {
            return new ProjectInfoPath(code);
        }

        public override string ToString()
        {
            return SubCodes.Count > 0
                ? $"{Code.ToDescriptionString()}/{string.Join("/", SubCodes)}"
                : Code.ToDescriptionString();
        }
    }

    [PublicAPI]
    public enum ProjectInfoPathCode
    {
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/targetLanguageIds")]
        TargetLanguageIds,
        
        [SerializedValue("/cname")]
        Cname,
        
        [SerializedValue("/visibility")]
        Visibility,
        
        [SerializedValue("/languageAccessPolicy")]
        LanguageAccessPolicy,
        
        [SerializedValue("/glossaryAccess")]
        GlossaryAccess,
        
        [SerializedValue("/description")]
        Description,
        
        [SerializedValue("/translateDuplicates")]
        TranslateDuplicates,
        
        [SerializedValue("/isMtAllowed")]
        IsMachineTranslationAllowed,
        
        [SerializedValue("/taskBasedAccessControl")]
        TaskBasedAccessControl,
        
        [SerializedValue("/autoSubstitution")]
        AutoSubstitution,
        
        [SerializedValue("/skipUntranslatedStrings")]
        SkipUntranslatedStrings,
        
        [SerializedValue("/skipUntranslatedFiles")]
        SkipUntranslatedFiles,
        
        [SerializedValue("/exportApprovedOnly")]
        ExportApprovedOnly,
        
        [SerializedValue("/autoTranslateDialects")]
        AutoTranslateDialects,
        
        [SerializedValue("/publicDownloads")]
        PublicDownloads,
        
        [SerializedValue("/hiddenStringsProofreadersAccess")]
        HiddenStringsProofreadersAccess,
        
        [SerializedValue("/useGlobalTm")]
        UseGlobalMachineTranslator,
        
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
        
        [SerializedValue("/qaCheckIsActive")]
        QaCheckIsActive,
        
        [SerializedValue("/qaCheckCategories")]
        QaCheckCategories,
        
        // /qaCheckCategories/{category}
        
        [SerializedValue("/languageMapping")]
        LanguageMapping,
        
        // /languageMapping/{languageId}
        
        // /languageMapping/{languageId}/{mappingKey}
        
        [SerializedValue("/notificationSettings/translatorNewStrings")]
        NotificationsTranslatorNewStrings,
        
        [SerializedValue("/notificationSettings/managerNewStrings")]
        NotificationsManagerNewStrings,
        
        [SerializedValue("/notificationSettings/managerLanguageCompleted")]
        NotificationsManagerLanguageCompleted
    }
}