
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public enum TranslationFormat
    {
        [SerializedValue("xliff")]
        Xliff,
        
        [SerializedValue("android")]
        Android,
        
        [SerializedValue("macosx")]
        MacOsX
    }
}