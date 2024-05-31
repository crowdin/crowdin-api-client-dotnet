
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ExportReportArchiveRequest
    {
        [JsonProperty("format")]
        public ReportFormat? Format { get; set; }
    }
}