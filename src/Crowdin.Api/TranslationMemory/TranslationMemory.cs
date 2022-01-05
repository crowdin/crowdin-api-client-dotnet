
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TranslationMemory
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("groupId")]
        public int? GroupId { get; set; }
        
        [JsonProperty("userId")]
        public int UserId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("languageIds")]
        public string[] LanguageIds { get; set; }
        
        [JsonProperty("segmentsCount")]
        public int SegmentsCount { get; set; }
        
        [JsonProperty("defaultProjectId")]
        public int DefaultProjectId { get; set; }
        
        [JsonProperty("projectIds")]
        public int[] ProjectIds { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}