
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public enum StringBasedProjectFileType
    {
        [Description("auto")]
        Auto,
        
        [Description("android")]
        Android,
        
        [Description("macosx")]
        MacOsX,
        
        [Description("arb")]
        Arb,
        
        [Description("csv")]
        Csv,
        
        [Description("json")]
        Json,
        
        [Description("xlsx")]
        Xlsx,
        
        [Description("xliff")]
        Xliff,
        
        [Description("xliff_two")]
        XliffTwo
    }
}