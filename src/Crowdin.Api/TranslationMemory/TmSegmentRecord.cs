
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TmSegmentRecord
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("usageCount")]
        public int UsageCount { get; set; }
        
        [JsonProperty("createdBy")]
        public int CreatedBy { get; set; }
        
        [JsonProperty("updatedBy")]
        public int? UpdatedBy { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}