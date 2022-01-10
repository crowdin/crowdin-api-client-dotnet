
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public enum UserStatus
    {
        [Description("active")]
        Active,
        
        [Description("pending")]
        Pending,
        
        [Description("blocked")]
        Blocked
    }
}