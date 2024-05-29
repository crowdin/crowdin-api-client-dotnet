
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public enum PreTranslationMethod
    {
        [SerializedValue("tm")]
        Tm,
        
        [SerializedValue("mt")]
        Mt
    }
}