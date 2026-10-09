#nullable enable

using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public enum AdvisorInsightMetricSource
    {
        [Description("deterministic")]
        Deterministic,

        [Description("ai")]
        Ai,

        [Description("app")]
        App
    }
}
