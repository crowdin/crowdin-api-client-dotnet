#nullable enable

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiFineTuningEvent
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        [JsonProperty("type")]
        public string Type { get; set; } = null!;

        [JsonProperty("message")]
        public string Message { get; set; } = null!;

        [JsonProperty("data")]
        public AiFineTuningEventData? Data { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
