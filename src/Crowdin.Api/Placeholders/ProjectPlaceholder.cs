#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public class ProjectPlaceholder
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("customPlaceholderId")]
        public long? CustomPlaceholderId { get; set; }

        [JsonProperty("type")]
        public ProjectPlaceholderType? Type { get; set; }

        [JsonProperty("index")]
        public int? Index { get; set; }

        [JsonProperty("isBlocking")]
        public bool? IsBlocking { get; set; }

        [JsonProperty("formats")]
        public string[] Formats { get; set; } = null!;
    }
}
