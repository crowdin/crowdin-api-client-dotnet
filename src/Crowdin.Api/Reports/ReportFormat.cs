
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public enum ReportFormat
    {
        [Description("xlsx")]
        Xlsx,
        
        [Description("csv")]
        Csv,
        
        [Description("json")]
        Json
    }
}