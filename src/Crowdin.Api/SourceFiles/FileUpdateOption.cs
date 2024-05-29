
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public enum FileUpdateOption
    {
        [SerializedValue("clear_translations_and_approvals")]
        ClearTranslationsAndApprovals,
        
        [SerializedValue("keep_translations")]
        KeepTranslations,
        
        [SerializedValue("keep_translations_and_approvals")]
        KeepTranslationsAndApprovals
    }
}