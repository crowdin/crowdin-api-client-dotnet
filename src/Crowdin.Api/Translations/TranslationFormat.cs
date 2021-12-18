
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public enum TranslationFormat
    {
        [Description("xliff")]
        Xliff,
        
        [Description("android")]
        Android,
        
        [Description("macosx")]
        MacOsX
    }
}