#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public enum AdvisorCheckStatus
    {
        [Description("created")]
        Created,

        [Description("inProgress")]
        InProgress,

        [Description("done")]
        Done,

        [Description("failed")]
        Failed
    }
}
