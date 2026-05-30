
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public enum QaCheckRevalidationCategory
    {
        [Description("terms")]
        Terms,

        [Description("ai")]
        Ai
    }
}
