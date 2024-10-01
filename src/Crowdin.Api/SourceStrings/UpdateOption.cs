
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.SourceStrings
{
    [PublicAPI]
    public enum UpdateOption
    {
        [Description("clear_translations_and_approvals")]
        ClearTranslationsAndApprovals,
        
        [Description("keep_translations")]
        KeepTranslations,
        
        [Description("keep_translations_and_approvals")]
        KeepTranslationsAndApprovals
    }
}