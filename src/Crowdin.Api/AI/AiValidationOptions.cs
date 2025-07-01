
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiValidationOptions
    {
        [JsonProperty("projectIds")]
        public List<long>? ProjectIds { get; set; }
        
        [JsonProperty("dateFrom")]
        public DateTimeOffset? DateFrom { get; set; }
        
        [JsonProperty("dateTo")]
        public DateTimeOffset? DateTo { get; set; }
        
        [JsonProperty("maxFileSize")]
        public long? MaxFileSize { get; set; }
        
        [JsonProperty("minExamplesCount")]
        public long? MinExamplesCount { get; set; }
        
        [JsonProperty("maxExamplesCount")]
        public long? MaxExamplesCount { get; set; }
    }
}