using System;

namespace Crowdin.Api
{
    public class DownloadTranslationParameters
    {
        [Ignore]
        public String Package { get; set; }

        public String Branch { get; set; }
    }
}