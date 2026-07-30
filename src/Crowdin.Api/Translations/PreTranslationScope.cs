
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public enum PreTranslationScope
    {
        [Description("untranslated")]
        Untranslated,

        [Description("translated")]
        Translated,

        [Description("all")]
        All
    }
}
