
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TranslationMemory
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("groupId")]
        public long? GroupId { get; set; }
        
        [JsonProperty("userId")]
        public long UserId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("languageIds")]
        public string[] LanguageIds { get; set; }
        
        [JsonProperty("segmentsCount")]
        public int SegmentsCount { get; set; }
        
        [JsonProperty("defaultProjectIds")]
        public long[] DefaultProjectIds { get; set; }
        
        [JsonProperty("projectIds")]
        public long[] ProjectIds { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}