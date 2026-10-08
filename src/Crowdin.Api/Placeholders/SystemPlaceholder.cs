#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public class SystemPlaceholder
    {
        [JsonProperty("id")]
        public SystemPlaceholderKey Id { get; set; }

        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; } = null!;

        [JsonProperty("description")]
        public string Description { get; set; } = null!;

        [JsonProperty("examples")]
        public string[] Examples { get; set; } = null!;
    }
}
