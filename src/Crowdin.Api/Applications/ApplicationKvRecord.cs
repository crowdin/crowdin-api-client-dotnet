#nullable enable

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class ApplicationKvRecord
    {
        [JsonProperty("key")]
        public string Key { get; set; } = null!;

        [JsonProperty("value")]
        public JToken Value { get; set; } = null!;

        [JsonProperty("secret")]
        public bool Secret { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("expiresAt")]
        public DateTimeOffset? ExpiresAt { get; set; }
    }
}
