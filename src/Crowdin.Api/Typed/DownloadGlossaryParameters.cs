using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public sealed class DownloadGlossaryParameters
    {
        [Property("include_assigned")]
        public Boolean? IncludeAssigned { get; set; }
    }
}