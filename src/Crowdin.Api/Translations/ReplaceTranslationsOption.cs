
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public enum ReplaceTranslationsOption
    {
        [Description("none")]
        None,

        [Description("autoTranslated")]
        AutoTranslated,

        [Description("all")]
        All
    }
}
