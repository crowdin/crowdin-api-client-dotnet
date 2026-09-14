#nullable enable

using System;

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiRequestLog
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; } = null!;

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("status")]
        public AiRequestLogStatus Status { get; set; }

        [JsonProperty("httpStatus")]
        public int? HttpStatus { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; } = null!;

        [JsonProperty("sourceAction")]
        public AiRequestLogSourceAction SourceAction { get; set; }

        [JsonProperty("promptAction")]
        public string? PromptAction { get; set; }

        [JsonProperty("systemCredentials")]
        public bool SystemCredentials { get; set; }

        [JsonProperty("isAutoTriggered")]
        public bool IsAutoTriggered { get; set; }

        [JsonProperty("durationMs")]
        public long? DurationMs { get; set; }

        [JsonProperty("inputTokens")]
        public long? InputTokens { get; set; }

        [JsonProperty("outputTokens")]
        public long? OutputTokens { get; set; }

        [JsonProperty("totalCost")]
        public float? TotalCost { get; set; }

        [JsonProperty("userId")]
        public long? UserId { get; set; }

        [JsonProperty("projectId")]
        public long? ProjectId { get; set; }

        [JsonProperty("promptId")]
        public long? PromptId { get; set; }

        [JsonProperty("aiProviderId")]
        public long AiProviderId { get; set; }

        [JsonProperty("tokenName")]
        public string? TokenName { get; set; }

        [JsonProperty("oauthClientId")]
        public string? OauthClientId { get; set; }

        [JsonProperty("oauthClientName")]
        public string? OauthClientName { get; set; }

        [JsonProperty("ip")]
        public string? Ip { get; set; }

        [JsonProperty("userAgent")]
        public string? UserAgent { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }
    }
}
