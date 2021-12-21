
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Screenshots
{
    [PublicAPI]
    public class Tag
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("screenshotId")]
        public int ScreenshotId { get; set; }
        
        [JsonProperty("stringId")]
        public int StringId { get; set; }
        
        [JsonProperty("position")]
        public Position Position { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}