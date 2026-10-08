#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public enum AdvisorInsightStatus
    {
        [Description("pending")]
        Pending,

        [Description("checking")]
        Checking,

        [Description("outdated")]
        Outdated,

        [Description("done")]
        Done
    }
}
