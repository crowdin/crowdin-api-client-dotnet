
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public enum TmFileFormat
    {
        [Description("tmx")]
        Tmx,
        
        [Description("csv")]
        Csv,
        
        [Description("xlsx")]
        Xlsx
    }
}