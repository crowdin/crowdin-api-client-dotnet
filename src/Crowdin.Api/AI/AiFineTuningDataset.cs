
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiFineTuningDataset
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("status")]
        public OperationStatus Status { get; set; }
        
        [JsonProperty("progress")]
        public int Progress { get; set; }
        
        [JsonProperty("attributes")]
        public AttributesObject Attributes { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
        
        [JsonProperty("startedAt")]
        public DateTimeOffset StartedAt { get; set; }
        
        [JsonProperty("finishedAt")]
        public DateTimeOffset FinishedAt { get; set; }

        [PublicAPI]
        public class AttributesObject
        {
            [JsonProperty("projectIds")]
            public int[] ProjectIds { get; set; }
            
            [JsonProperty("purpose")]
            public AiDatasetPurpose Purpose { get; set; }
            
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
            
            [JsonProperty("maxFileSize")]
            public int? MaxFileSize { get; set; }
        
            [JsonProperty("minExamplesCount")]
            public int? MinExamplesCount { get; set; }
        
            [JsonProperty("maxExamplesCount")]
            public int? MaxExamplesCount { get; set; }
        }
    }
}