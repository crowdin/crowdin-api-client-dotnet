
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Bundles
{
    [PublicAPI]
    public class Bundle
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("format")]
        public string Format { get; set; }
        
        [JsonProperty("sourcePatterns")]
        public string[] SourcePatterns { get; set; }
        
        [JsonProperty("ignorePatterns")]
        public string[] IgnorePatterns { get; set; }
        
        [JsonProperty("exportPattern")]
        public string ExportPattern { get; set; }
        
        [JsonProperty("isMultilingual")]
        public bool IsMultilingual { get; set; }
        
        [JsonProperty("labelIds")]
        public int[] LabelIds { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}