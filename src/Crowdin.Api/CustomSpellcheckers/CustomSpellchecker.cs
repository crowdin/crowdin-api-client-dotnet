#nullable enable

using System;

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.CustomSpellcheckers
{
    [PublicAPI]
    public class CustomSpellchecker
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("config")]
        public CustomSpellcheckerConfig Config { get; set; } = null!;

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
