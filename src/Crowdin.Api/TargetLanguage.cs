using System;
using Crowdin.Api.Json;
using Newtonsoft.Json;

namespace Crowdin.Api
{
    public sealed class TargetLanguage : Language
    {
        [JsonProperty("can_translate")]
        [JsonConverter(typeof(BooleanConverter))]
        public Boolean CanTranslate { get; private set; }

        [JsonProperty("can_approve")]
        [JsonConverter(typeof(BooleanConverter))]
        public Boolean CanApprove { get; private set; }
    }
}
