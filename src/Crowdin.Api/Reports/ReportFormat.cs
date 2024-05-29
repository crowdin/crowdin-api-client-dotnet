
using System.ComponentModel;
using JetBrains.Annotations;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public enum ReportFormat
    {
        [SerializedValue("xlsx")]
        Xlsx,
        
        [SerializedValue("csv")]
        Csv,
        
        [SerializedValue("json")]
        Json
    }
}