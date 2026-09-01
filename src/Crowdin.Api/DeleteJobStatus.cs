using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api
{
    [PublicAPI]
    public class DeleteJobStatus
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; } = null!;

        [JsonProperty("status")]
        public OperationStatus Status { get; set; }

        [JsonProperty("progress")]
        public long Progress { get; set; }

        [JsonProperty("attributes")]
        public AttributesData Attributes { get; set; } = null!;

        [JsonProperty("error")]
        public ErrorData? Error { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("startedAt")]
        public DateTimeOffset? StartedAt { get; set; }

        [JsonProperty("finishedAt")]
        public DateTimeOffset? FinishedAt { get; set; }

        [PublicAPI]
        public class AttributesData
        {
            [JsonProperty("branchId")]
            public long? BranchId { get; set; }

            [JsonProperty("directoryId")]
            public long? DirectoryId { get; set; }

            [JsonProperty("fileId")]
            public long? FileId { get; set; }
        }

        [PublicAPI]
        public class ErrorData
        {
            [JsonProperty("message")]
            public string Message { get; set; } = null!;
        }
    }
}