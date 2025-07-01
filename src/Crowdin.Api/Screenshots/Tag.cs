
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Screenshots
{
    [PublicAPI]
    public class Tag
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("screenshotId")]
        public long ScreenshotId { get; set; }
        
        [JsonProperty("stringId")]
        public long StringId { get; set; }
        
        [JsonProperty("position")]
        public Position Position { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}