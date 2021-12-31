
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public enum TaskStatus
    {
        [Description("todo")]
        Todo,
        
        [Description("in_progress")]
        InProgress,
        
        [Description("done")]
        Done,
        
        [Description("closed")]
        Closed
    }
}