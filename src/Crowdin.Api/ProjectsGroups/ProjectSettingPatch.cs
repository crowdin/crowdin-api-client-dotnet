
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
        [SerializedValue("/translateDuplicates")]
        TranslateDuplicates,
        
        [SerializedValue("/isMtAllowed")]
        IsMtAllowed,
        
        [SerializedValue("/autoSubstitution")]
        AutoSubstitution,
        
        [SerializedValue("/skipUntranslatedFiles")]
        SkipUntranslatedFiles,
        
        [SerializedValue("/skipUntranslatedStrings")]
        SkipUntranslatedStrings,
        
        [SerializedValue("/exportApprovedOnly")]
        ExportApprovedOnly,
        
        [SerializedValue("/autoTranslateDialects")]
        AutoTranslateDialects,
        
        [SerializedValue("/publicDownloads")]
        PublicDownloads,
        
        [SerializedValue("/useGlobalTm")]
        UseGlobalTm,
        
        [SerializedValue("/showTmSuggestionsDialects")]
        ShowTmSuggestionsDialects,
        
        [SerializedValue("/normalizePlaceholder")]
        NormalizePlaceholder,
        
        [SerializedValue("/saveMetaInfoInSource")]
        SaveMetaInfoInSource,
        
        [SerializedValue("/inContext")]
        InContext,
        
        [SerializedValue("/inContextPseudoLanguageId")]
        InContextPseudoLanguageId,
        
        [SerializedValue("/inContextProcessHiddenStrings")]
        InContextProcessHiddenStrings,
        
        [SerializedValue("/pseudoLanguageId")]
        PseudoLanguageId,
        
        [SerializedValue("/qaCheckIsActive")]
        QaCheckIsActive,
        
        [SerializedValue("/qaCheckCategories")]
        QaCheckCategories,
        
        [SerializedValue("/qaChecksIgnorableCategories")]
        QaChecksIgnorableCategories,
        
        // /qaCheckCategories/{category}
        
        [SerializedValue("/languageMapping")]
        LanguageMapping,
        
        // /languageMapping/{languageId}
        
        // /languageMapping/{languageId}/{mappingKey}
        
        [SerializedValue("/tmPenalties")]
        TmPenalties,
        
        // /tmPenalties/{penaltyKey}
        
        [SerializedValue("/tmContextType")]
        TmContextType,
        
        [SerializedValue("/tmPreTranslate")]
        TmPreTranslate,
        
        [SerializedValue("/mtPreTranslate")]
        MtPreTranslate,
    }
}