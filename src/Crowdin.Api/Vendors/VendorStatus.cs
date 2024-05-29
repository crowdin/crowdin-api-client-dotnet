
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Vendors
{
    [PublicAPI]
    public enum VendorStatus
    {
        [SerializedValue("pending")]
        Pending,
        
        [SerializedValue("confirmed")]
        Confirmed,
        
        [SerializedValue("rejected")]
        Rejected,
        
        [SerializedValue("deleted")]
        Deleted
    }
}