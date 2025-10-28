using Crowdin.Api.Users;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class AssetReference
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("mimeType")]
        public string MimeType { get; set; }
    }
}
