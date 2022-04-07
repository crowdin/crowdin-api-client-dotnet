
using System.Collections.Generic;
using System.ComponentModel;
using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;
using JetBrains.Annotations;
using Newtonsoft.Json;

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
        [Description("/translateDuplicates")]
        TranslateDuplicates,
        
        [Description("/isMtAllowed")]
        IsMtAllowed,
        
        [Description("/autoSubstitution")]
        AutoSubstitution,
        
        [Description("/skipUntranslatedStrings")]
        SkipUntranslatedStrings,
        
        [Description("/exportWithMinApprovalsCount")]
        ExportWithMinApprovalsCount,
        
        [Description("/autoTranslateDialects")]
        AutoTranslateDialects,
        
        [Description("/publicDownloads")]
        PublicDownloads,
        
        [Description("/normalizePlaceholder")]
        NormalizePlaceholder,
        
        [Description("/saveMetaInfoInSource")]
        SaveMetaInfoInSource,
        
        [Description("/inContext")]
        InContext,
        
        [Description("/pseudoLanguageId")]
        PseudoLanguageId,
        
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