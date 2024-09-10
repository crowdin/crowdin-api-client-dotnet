
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public enum AiReportFormat
    {
        [Description("json")]
        Json,
        
        [Description("csv")]
        Csv
    }
}