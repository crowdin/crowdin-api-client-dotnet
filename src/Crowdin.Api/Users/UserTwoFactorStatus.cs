
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public enum UserTwoFactorStatus
    {
        [SerializedValue("enabled")]
        Enabled,
        
        [SerializedValue("disabled")]
        Disabled
    }
}