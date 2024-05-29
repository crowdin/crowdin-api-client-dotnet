
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Issues
{
    [PublicAPI]
    public enum IssueStatus
    {
        [SerializedValue("all")]
        All,
        
        [SerializedValue("resolved")]
        Resolved,
        
        [SerializedValue("unresolved")]
        UnResolved
    }
}