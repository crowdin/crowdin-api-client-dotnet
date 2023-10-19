
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum BuildStatus
    {
        [Description("created")]
        Created,

        [Description("in_progress")]
        InProgress,

        [Description("finished")]
        Finished,
        
        [Description("failed")]
        Failed,
        
        [Description("canceled")]
        Canceled
    }
}