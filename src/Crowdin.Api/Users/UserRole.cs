
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public enum UserRole
    {
        [Description("all")]
        All,
        
        [Description("manager")]
        Manager,
        
        [Description("proofreader")]
        Proofreader,
        
        [Description("translator")]
        Translator,
        
        [Description("blocked")]
        Blocked
    }
}