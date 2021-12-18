
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Languages
{
    [PublicAPI]
    public enum LanguagePatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/textDirection")]
        TextDirection,
        
        [Description("/pluralCategoryNames")]
        PluralCategoryNames,
        
        [Description("/threeLettersCode")]
        ThreeLettersCode,
        
        [Description("/localeCode")]
        LocaleCode,
        
        [Description("/dialectOf")]
        DialectOf
    }
}