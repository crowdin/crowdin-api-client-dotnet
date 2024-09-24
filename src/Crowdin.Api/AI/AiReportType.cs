
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiReportType
    {
        [Description("tokens-usage-raw-data")]
        TokensUsageRawData
    }
}