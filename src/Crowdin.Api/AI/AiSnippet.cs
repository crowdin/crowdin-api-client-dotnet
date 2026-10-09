#nullable enable

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiSnippet
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; } = null!;

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; } = null!;

        [JsonProperty("value")]
        public string Value { get; set; } = null!;

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
