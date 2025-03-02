
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Workflows
{
    [PublicAPI]
    public enum WorkflowStatus
    {
        [Description("todo")]
        ToDo,
        
        [Description("done")]
        Done,
        
        [Description("pending")]
        Pending,
        
        [Description("incomplete")]
        Incomplete,
        
        [Description("need_review")]
        NeedReview
    }
}