
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TmImportStatus
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("status")]
        public OperationStatus Status { get; set; }
        
        [JsonProperty("progress")]
        public int Progress { get; set; }
        
        [JsonProperty("attributes")]
        public ImportAttributes Attributes { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
        
        [JsonProperty("startedAt")]
        public DateTimeOffset? StartedAt { get; set; }
        
        [JsonProperty("finishedAt")]
        public DateTimeOffset? FinishedAt { get; set; }

        [PublicAPI]
        public class ImportAttributes
        {
            [JsonProperty("tmId")]
            public int TmId { get; set; }
            
            [JsonProperty("storageId")]
            public long StorageId { get; set; }
            
            [JsonProperty("firstLineContainsHeader")]
            public int FirstLineContainsHeader { get; set; }
            
            [JsonProperty("scheme")]
            public IDictionary<string, int> Scheme { get; set; }
        }
    }
}