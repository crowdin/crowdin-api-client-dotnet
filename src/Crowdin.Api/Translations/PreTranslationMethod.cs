
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public enum PreTranslationMethod
    {
        [Description("tm")]
        Tm,
        
        [Description("mt")]
        Mt
    }
}