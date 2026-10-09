#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public enum AdvisorInsightRefreshPolicy
    {
        [Description("hourly")]
        Hourly,

        [Description("daily")]
        Daily
    }
}
