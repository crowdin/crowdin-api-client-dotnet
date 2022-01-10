
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Vendors
{
    [PublicAPI]
    public enum VendorStatus
    {
        [Description("pending")]
        Pending,
        
        [Description("confirmed")]
        Confirmed,
        
        [Description("rejected")]
        Rejected,
        
        [Description("deleted")]
        Deleted
    }
}