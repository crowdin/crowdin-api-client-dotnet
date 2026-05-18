
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public enum TranslationFormat
    {
        #region System

        [Description("xliff")]
        Xliff,
        
        [Description("android")]
        Android,
        
        [Description("macosx")]
        MacOsX,

        #endregion
        
        [Description("crowdin-resx")]
        CrowdinResX,

        [Description("crowdin-json")]
        CrowdinJson,
        
        [Description("crowdin-csv")]
        CrowdinCsv,
        
        [Description("multilingual-csv-export")]
        MultilingualCsvExport,
        
        [Description("stringsdict-export")]
        StringsdictExport,
        
        [Description("yaml-export")]
        YamlExport,
        
        [Description("po-export")]
        PoExport,
                
        [Description("arb-export")]
        ArbExport,
        
        [Description("lingui-minimal")]
        LinguiMinimal,
        
        [Description("xcstrings")]
        Xcstrings,
        
        [Description("steam-multilingual-vdf")]
        SteamMultilingualVdf,
    }
}