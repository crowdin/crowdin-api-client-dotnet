using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public sealed class ExportTopMembersReportParameters
    {
        public ReportUnit? Unit { get; set; }

        public String Language { get; set; }

        [Property("date_from")]
        public DateTime? DateFrom { get; set; }

        [Property("date_to")]
        public DateTime? DateTo { get; set; }

        public String Format { get; set; }
    }
}