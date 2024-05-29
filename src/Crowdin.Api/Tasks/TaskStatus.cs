
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public enum TaskStatus
    {
        [SerializedValue("todo")]
        Todo,
        
        [SerializedValue("in_progress")]
        InProgress,
        
        [SerializedValue("done")]
        Done,
        
        [SerializedValue("closed")]
        Closed
    }
}