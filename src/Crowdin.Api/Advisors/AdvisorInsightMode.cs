#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public enum AdvisorInsightMode
    {
        [Description("auto")]
        Auto,

        [Description("all")]
        All
    }
}
