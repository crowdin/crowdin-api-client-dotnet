
using System.Collections.Generic;
using System.ComponentModel;
using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;
using JetBrains.Annotations;
using Newtonsoft.Json;

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
        [Description("/name")]
        Name,
        
        [Description("/targetLanguageIds")]
        TargetLanguageIds,
        
        [Description("/cname")]
        Cname,
        
        [Description("/visibility")]
        Visibility,
        
        [Description("/languageAccessPolicy")]
        LanguageAccessPolicy,
        
        [Description("/glossaryAccess")]
        GlossaryAccess,
        
        [Description("/description")]
        Description,
        
        [Description("/translateDuplicates")]
        TranslateDuplicates,
        
        [Description("/isMtAllowed")]
        IsMachineTranslationAllowed,
        
        [Description("/autoSubstitution")]
        AutoSubstitution,
        
        [Description("/skipUntranslatedStrings")]
        SkipUntranslatedStrings,
        
        [Description("/skipUntranslatedFiles")]
        SkipUntranslatedFiles,
        
        [Description("/exportApprovedOnly")]
        ExportApprovedOnly,
        
        [Description("/autoTranslateDialects")]
        AutoTranslateDialects,
        
        [Description("/publicDownloads")]
        PublicDownloads,
        
        [Description("/hiddenStringsProofreadersAccess")]
        HiddenStringsProofreadersAccess,
        
        [Description("/useGlobalTm")]
        UseGlobalMachineTranslator,
        
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
        
        [Description("/qaCheckIsActive")]
        QaCheckIsActive,
        
        [Description("/qaCheckCategories")]
        QaCheckCategories,
        
        // /qaCheckCategories/{category}
        
        [Description("/languageMapping")]
        LanguageMapping,
        
        // /languageMapping/{languageId}
        
        // /languageMapping/{languageId}/{mappingKey}
        
        [Description("/notificationSettings/translatorNewStrings")]
        NotificationsTranslatorNewStrings,
        
        [Description("/notificationSettings/managerNewStrings")]
        NotificationsManagerNewStrings,
        
        [Description("/notificationSettings/managerLanguageCompleted")]
        NotificationsManagerLanguageCompleted
    }
}