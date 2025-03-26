
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public enum OrganizationRole
    {
        [Description("admin")]
        Admin,
        
        [Description("manager")]
        Manager,
        
        [Description("vendor")]
        Vendor,
        
        [Description("client")]
        Client
    }
}