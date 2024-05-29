
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum BuildStatus
    {
        [SerializedValue("created")]
        Created,

        [SerializedValue("inProgress")]
        [SerializedValue("in_progress")]
        InProgress,

        [SerializedValue("finished")]
        Finished,
        
        [SerializedValue("failed")]
        Failed,
        
        [SerializedValue("canceled")]
        Canceled
    }
}