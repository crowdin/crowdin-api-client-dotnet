
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.StringComments
{
    [PublicAPI]
    public enum IssueStatus
    {
        [SerializedValue("resolved")]
        Resolved,
        
        [SerializedValue("unresolved")]
        UnResolved
    }
}