using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public class DownloadTranslationMemoryParameters
    {
        [Property("include_assigned")]
        public Boolean? IncludeAssigned { get; set; }

        [Property("source_language")]
        public String SourceLanguage { get; set; }

        [Property("target_language")]
        public String TargetLanguage { get; set; }
    }
}