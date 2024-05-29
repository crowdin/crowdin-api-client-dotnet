
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public enum StringBasedProjectFileType
    {
        [SerializedValue("auto")]
        Auto,
        
        [SerializedValue("android")]
        Android,
        
        [SerializedValue("macosx")]
        MacOsX,
        
        [SerializedValue("arb")]
        Arb,
        
        [SerializedValue("csv")]
        Csv,
        
        [SerializedValue("json")]
        Json,
        
        [SerializedValue("xlsx")]
        Xlsx,
        
        [SerializedValue("xliff")]
        Xliff,
        
        [SerializedValue("xliff_two")]
        XliffTwo
    }
}