#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.CustomSpellcheckers
{
    [PublicAPI]
    public class CustomSpellcheckerConfig
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; } = null!;

        [JsonProperty("key")]
        public string Key { get; set; } = null!;

        [JsonProperty("realTimeCheckEnabled")]
        public bool RealTimeCheckEnabled { get; set; }

        [JsonProperty("enabledLanguageIds")]
        public string[] EnabledLanguageIds { get; set; } = null!;
    }
}
