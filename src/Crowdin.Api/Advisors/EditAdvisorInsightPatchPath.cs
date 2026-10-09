#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Advisors
{
    [PublicAPI]
    public enum EditAdvisorInsightPatchPath
    {
        [Description("/isDismissed")]
        IsDismissed
    }
}
