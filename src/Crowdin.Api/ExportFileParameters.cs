using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api
{
    public sealed class ExportFileParameters
    {
        [Required]
        public String File { get; set; }

        [Required]
        public String Language { get; set; }

        public String Branch { get; set; }

        public String Format { get; set; }

        [Property("export_translated_only")]
        public Boolean? ExportTranslatedOnly { get; set; }

        [Property("export_approved_only")]
        public Boolean? ExportApprovedOnly { get; set; }
    }
}