
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Screenshots
{
    [PublicAPI]
    public class Screenshot
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("userId")]
        public long UserId { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("size")]
        public Size Size { get; set; }
        
        [JsonProperty("tagsCount")]
        public int TagsCount { get; set; }
        
        [JsonProperty("tags")]
        public Tag[] Tags { get; set; }
        
        [JsonProperty("labelIds")]
        public int[] LabelIds { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}