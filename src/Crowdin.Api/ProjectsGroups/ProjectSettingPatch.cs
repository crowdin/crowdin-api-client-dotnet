
using System.Collections.Generic;
using System.ComponentModel;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;
using Crowdin.Api.Core.Converters;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class ProjectSettingPatch : ProjectPatch
    {
        [JsonProperty("path")]
        public ProjectSettingPath Path { get; set; }
    }

    [PublicAPI]
    [CallToStringForSerialization]
    public class ProjectSettingPath
    {
        public ProjectSettingPathCode Code { get; set; }

        public ICollection<string> SubCodes { get; set; } = new List<string>();

        public ProjectSettingPath()
        {
            
        }
        
        public ProjectSettingPath(ProjectSettingPathCode code)
        {
            Code = code;
        }

        public ProjectSettingPath(ProjectSettingPathCode code, params string[] subCodes)
        {
            Code = code;
            SubCodes = subCodes;
        }

        public static implicit operator ProjectSettingPath(ProjectSettingPathCode code)
        {
            return new ProjectSettingPath(code);
        }

        public override string ToString()
        {
            return SubCodes.Count > 0
                ? $"{Code.ToDescriptionString()}/{string.Join("/", SubCodes)}"
                : Code.ToDescriptionString();
        }
    }

    [PublicAPI]
    public enum ProjectSettingPathCode
    {
        [Description("/translateDuplicates")]
        TranslateDuplicates,
        
        [Description("/isMtAllowed")]
        IsMtAllowed,
        
        [Description("/autoSubstitution")]
        AutoSubstitution,
        
        [Description("/skipUntranslatedFiles")]
        SkipUntranslatedFiles,
        
        [Description("/skipUntranslatedStrings")]
        SkipUntranslatedStrings,
        
        [Description("/exportApprovedOnly")]
        ExportApprovedOnly,
        
        [Description("/autoTranslateDialects")]
        AutoTranslateDialects,
        
        [Description("/publicDownloads")]
        PublicDownloads,
        
        [Description("/useGlobalTm")]
        UseGlobalTm,
        
        [Description("/showTmSuggestionsDialects")]
        ShowTmSuggestionsDialects,
        
        [Description("/normalizePlaceholder")]
        NormalizePlaceholder,
        
        [Description("/saveMetaInfoInSource")]
        SaveMetaInfoInSource,
        
        [Description("/inContext")]
        InContext,
        
        [Description("/inContextPseudoLanguageId")]
        InContextPseudoLanguageId,
        
        [Description("/inContextProcessHiddenStrings")]
        InContextProcessHiddenStrings,
        
        [Description("/pseudoLanguageId")]
        PseudoLanguageId,
        
        [Description("/qaCheckIsActive")]
        QaCheckIsActive,
        
        [Description("/qaCheckCategories")]
        QaCheckCategories,
        
        [Description("/qaChecksIgnorableCategories")]
        QaChecksIgnorableCategories,
        
        // /qaCheckCategories/{category}
        
        [Description("/languageMapping")]
        LanguageMapping,
        
        // /languageMapping/{languageId}
        
        // /languageMapping/{languageId}/{mappingKey}
        
        [Description("/tmPenalties")]
        TmPenalties,
        
        // /tmPenalties/{penaltyKey}
        
        [Description("/tmContextType")]
        TmContextType,
        
        [Description("/tmPreTranslate")]
        TmPreTranslate,
        
        [Description("/mtPreTranslate")]
        MtPreTranslate,
        
        [Description("/defaultTmId")]
        DefaultTmId,
        
        [Description("/defaultGlossaryId")]
        DefaultGlossaryId
    }
}