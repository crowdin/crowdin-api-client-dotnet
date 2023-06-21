
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api
{
    [PublicAPI]
    public enum OperationStatus
    {
        [Description("created")]
        Created,

        [Description("inProgress")]
        InProgress,

        [Description("finished")]
        Finished,
        
        [Description("failed")]
        Failed,
        
        [Description("canceled")]
        Canceled
    }
}