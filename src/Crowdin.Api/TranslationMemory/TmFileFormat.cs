
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public enum TmFileFormat
    {
        [SerializedValue("tmx")]
        Tmx,
        
        [SerializedValue("csv")]
        Csv,
        
        [SerializedValue("xlsx")]
        Xlsx
    }
}