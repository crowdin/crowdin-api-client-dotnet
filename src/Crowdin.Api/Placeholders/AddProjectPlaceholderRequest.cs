#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public class AddProjectPlaceholderRequest
    {
        [JsonProperty("customPlaceholderId")]
        public long CustomPlaceholderId { get; set; }

        [JsonProperty("type")]
        public ProjectPlaceholderType? Type { get; set; } = ProjectPlaceholderType.Low;

        [JsonProperty("index")]
        public int? Index { get; set; } = 0;

        [JsonProperty("isBlocking")]
        public bool? IsBlocking { get; set; } = false;

        [JsonProperty("formats")]
        public string[]? Formats { get; set; }
    }
}
