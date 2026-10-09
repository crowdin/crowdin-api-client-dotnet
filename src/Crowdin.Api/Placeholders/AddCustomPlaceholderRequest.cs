#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public class AddCustomPlaceholderRequest
    {
        [JsonProperty("definition")]
        public string Definition { get; set; } = null!;

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("argumentDelimiter")]
        public string? ArgumentDelimiter { get; set; } = "\"";
    }
}
