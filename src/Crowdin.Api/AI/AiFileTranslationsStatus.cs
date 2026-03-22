
using System;
using Crowdin.Api.SourceFiles;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiFileTranslationsStatus
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; } = null!;
        
        [JsonProperty("status")]
        public OperationStatus Status { get; set; }
        
        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("attributes")]
        public AttributesObject Attributes { get; set; } = null!;

        [PublicAPI]
        public class AttributesObject
        {
            [JsonProperty("stage")]
            public AiFileTranslationsStage Stage { get; set; }
            
            [JsonProperty("error")]
            public ErrorObject? Error { get; set; }
            
            [JsonProperty("downloadName")]
            public string? DownloadName { get; set; }
            
            [JsonProperty("sourceLanguageId")]
            public string? SourceLanguageId { get; set; }
            
            [JsonProperty("targetLanguageId")]
            public string? TargetLanguageId { get; set; }
            
            [JsonProperty("originalFileName")]
            public string? OriginalFileName { get; set; }
            
            [JsonProperty("detectedType")]
            public ProjectFileType? DetectedType { get; set; }
            
            [JsonProperty("parserVersion")]
            public int? ParserVersion { get; set; }
            
            [PublicAPI]
            public class ErrorObject
            {
                [JsonProperty("stage")]
                public AiFileTranslationsStage Stage { get; set; }

                [JsonProperty("message")]
                public string Message { get; set; } = null!;
            }
        }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
        
        [JsonProperty("startedAt")]
        public DateTimeOffset? StartedAt { get; set; }
        
        [JsonProperty("finishedAt")]
        public DateTimeOffset? FinishedAt { get; set; }
    }
}