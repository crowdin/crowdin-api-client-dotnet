
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public enum UserStatus
    {
        [SerializedValue("active")]
        Active,
        
        [SerializedValue("pending")]
        Pending,
        
        [SerializedValue("blocked")]
        Blocked
    }
}