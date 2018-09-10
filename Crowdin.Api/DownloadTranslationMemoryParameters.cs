using System;

namespace Crowdin.Api
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