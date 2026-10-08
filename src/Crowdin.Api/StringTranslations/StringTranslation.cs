
#nullable enable annotations

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class StringTranslation
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("pluralCategoryName")]
        public PluralCategoryName PluralCategoryName { get; set; }
        
        [JsonProperty("user")]
        public User User { get; set; }
        
        [JsonProperty("rating")]
        public int Rating { get; set; }
        
        [JsonProperty("provider")]
        public string Provider { get; set; }
        
        [JsonProperty("isPreTranslated")]
        public bool IsPreTranslated { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("providerId")]
        public long? ProviderId { get; set; }

        [JsonProperty("matchRate")]
        public int? MatchRate { get; set; }

        [JsonProperty("matchType")]
        public string? MatchType { get; set; }

        [JsonProperty("qaIssuesStatus")]
        public string? QaIssuesStatus { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("workflowStepId")]
        public long? WorkflowStepId { get; set; }
    }
}
