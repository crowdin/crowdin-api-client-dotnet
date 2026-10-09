#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public class CustomPlaceholder
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("definition")]
        public string? Definition { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("argumentDelimiter")]
        public string? ArgumentDelimiter { get; set; }
    }
}
