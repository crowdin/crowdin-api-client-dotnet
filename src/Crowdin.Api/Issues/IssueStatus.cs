
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Issues
{
    [PublicAPI]
    public enum IssueStatus
    {
        [Description("all")]
        All,
        
        [Description("resolved")]
        Resolved,
        
        [Description("unresolved")]
        UnResolved
    }
}