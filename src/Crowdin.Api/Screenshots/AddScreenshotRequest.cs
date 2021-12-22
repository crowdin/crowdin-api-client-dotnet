
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Screenshots
{
    [PublicAPI]
    public class AddScreenshotRequest
    {
        [JsonProperty("storageId")]
        public int StorageId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("autoTag")]
        public bool? AutoTag { get; set; }
    }
}