using System;
using Newtonsoft.Json;

namespace Crowdin.Api
{
    public class ProjectInviteUrls
    {
        [JsonProperty("translator")]
        public Uri Translator { get; private set; }

        [JsonProperty("proofreader")]
        public Uri Proofreader { get; private set; }
    }
}
