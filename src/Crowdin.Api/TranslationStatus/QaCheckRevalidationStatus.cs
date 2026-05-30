
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public class QaCheckRevalidationStatus
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("status")]
        public OperationStatus Status { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("attributes")]
        public RevalidationAttributes Attributes { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("startedAt")]
        public DateTimeOffset? StartedAt { get; set; }

        [JsonProperty("finishedAt")]
        public DateTimeOffset? FinishedAt { get; set; }

        [PublicAPI]
        public class RevalidationAttributes
        {
            [JsonProperty("languageIds")]
            public string[] LanguageIds { get; set; }

            [JsonProperty("qaCheckCategories")]
            public QaCheckRevalidationCategory[] QaCheckCategories { get; set; }

            [JsonProperty("failedOnly")]
            public bool FailedOnly { get; set; }
        }
    }
}
