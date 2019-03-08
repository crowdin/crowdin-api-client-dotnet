using System;
using Crowdin.Api.Protocol;

namespace Crowdin.Api.Typed
{
    public class DownloadTranslationParameters
    {
        [Ignore]
        public String Package { get; set; }

        public String Branch { get; set; }
    }
}