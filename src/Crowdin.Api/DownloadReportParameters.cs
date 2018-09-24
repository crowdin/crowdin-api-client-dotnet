using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
    public sealed class DownloadReportParameters
    {
        [Required]
        public String Hash { get; set; }
    }
}
