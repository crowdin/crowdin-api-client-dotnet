#nullable enable

using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public enum AdvisorInsightMetricUnit
    {
        [Description("percent")]
        Percent,

        [Description("count")]
        Count
    }
}
