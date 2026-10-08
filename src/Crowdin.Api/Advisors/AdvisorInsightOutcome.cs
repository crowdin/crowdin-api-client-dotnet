#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public enum AdvisorInsightOutcome
    {
        [Description("flagged")]
        Flagged,

        [Description("clear")]
        Clear,

        [Description("notApplicable")]
        NotApplicable
    }
}
