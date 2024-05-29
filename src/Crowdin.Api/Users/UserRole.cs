
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public enum UserRole
    {
        [SerializedValue("all")]
        All,
        
        [SerializedValue("owner")]
        Owner,
        
        [SerializedValue("manager")]
        Manager,
        
        [SerializedValue("proofreader")]
        Proofreader,
        
        [SerializedValue("translator")]
        Translator,
        
        [SerializedValue("blocked")]
        Blocked
    }
}