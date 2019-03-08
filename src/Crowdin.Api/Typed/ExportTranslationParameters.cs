using System;

namespace Crowdin.Api.Typed
{
    public class ExportTranslationParameters
    {
        public String Branch { get; set; }

        public Boolean? Async { get; set; }
    }
}