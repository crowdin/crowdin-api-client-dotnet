
using System.ComponentModel;

using JetBrains.Annotations;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public enum ApplicationConsentStatus
    {
        [Description("granted")]
        Granted,

        [Description("denied")]
        Denied
    }
}
