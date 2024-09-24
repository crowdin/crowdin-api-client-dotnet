
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class GenerateAiPromptFineTuningDatasetRequest
    {
        [JsonProperty("projectIds")]
        public ICollection<int> ProjectIds { get; set; }
        
        [JsonProperty("purpose")]
        public AiDatasetPurpose? Purpose { get; set; }
        
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