using System;

namespace Crowdin.Api
{
    public sealed class DownloadGlossaryParameters
    {
        [Property("include_assigned")]
        public Boolean? IncludeAssigned { get; set; }
    }
}