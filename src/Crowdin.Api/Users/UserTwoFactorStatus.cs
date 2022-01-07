
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public enum UserTwoFactorStatus
    {
        [Description("enabled")]
        Enabled,
        
        [Description("disabled")]
        Disabled
    }
}