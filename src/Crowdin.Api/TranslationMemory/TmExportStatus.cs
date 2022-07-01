
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TmExportStatus
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("attributes")]
        public ExportAttributes Attributes { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
        
        [JsonProperty("startedAt")]
        public DateTimeOffset? StartedAt { get; set; }
        
        [JsonProperty("finishedAt")]
        public DateTimeOffset? FinishedAt { get; set; }
        
        [JsonProperty("eta")]
        public string Eta { get; set; }

        [PublicAPI]
        public class ExportAttributes
        {
            [JsonProperty("sourceLanguageId")]
            public string SourceLanguageId { get; set; }
            
            [JsonProperty("targetLanguageId")]
            public string TargetLanguageId { get; set; }
            
            [JsonProperty("format")]
            public TmFileFormat Format { get; set; }
        }
    }
}