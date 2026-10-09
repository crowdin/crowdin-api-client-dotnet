#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public enum AdvisorInsightSeverity
    {
        [Description("high")]
        High,

        [Description("medium")]
        Medium,

        [Description("low")]
        Low
    }
}
