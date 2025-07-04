﻿
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Screenshots
{
    [PublicAPI]
    public class AddScreenshotRequest
    {
        [JsonProperty("storageId")]
        public long StorageId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("autoTag")]
        public bool? AutoTag { get; set; }
                
        [JsonProperty("labelIds")]
        public long[] LabelIds { get; set; }
    }
}