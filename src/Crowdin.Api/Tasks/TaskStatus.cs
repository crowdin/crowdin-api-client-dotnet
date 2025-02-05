
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public enum TaskStatus
    {
        [Description("todo")]
        Todo,
        
        [Description("pending")]
        Pending,
        
        [Description("in_progress")]
        InProgress,
        
        [Description("review")]
        Review,
        
        [Description("done")]
        Done,
        
        [Description("closed")]
        Closed
    }
}