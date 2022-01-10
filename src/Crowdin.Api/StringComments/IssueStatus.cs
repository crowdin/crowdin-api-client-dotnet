
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public enum IssueStatus
    {
        [Description("resolved")]
        Resolved,
        
        [Description("unresolved")]
        UnResolved
    }
}