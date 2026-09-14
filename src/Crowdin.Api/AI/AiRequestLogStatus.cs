#nullable enable

using System.ComponentModel;

using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiRequestLogStatus
    {
        [Description("pending")]
        Pending,

        [Description("success")]
        Success,

        [Description("error")]
        Error,

        [Description("timeout")]
        Timeout
    }
}
