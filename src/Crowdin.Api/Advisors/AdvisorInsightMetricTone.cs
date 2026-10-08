#nullable enable

using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public enum AdvisorInsightMetricTone
    {
        [Description("default")]
        Default,

        [Description("success")]
        Success,

        [Description("danger")]
        Danger
    }
}
