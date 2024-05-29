
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Languages
{
    [PublicAPI]
    public enum LanguagePatchPath
    {
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/textDirection")]
        TextDirection,
        
        [SerializedValue("/pluralCategoryNames")]
        PluralCategoryNames,
        
        [SerializedValue("/threeLettersCode")]
        ThreeLettersCode,
        
        [SerializedValue("/localeCode")]
        LocaleCode,
        
        [SerializedValue("/dialectOf")]
        DialectOf
    }
}