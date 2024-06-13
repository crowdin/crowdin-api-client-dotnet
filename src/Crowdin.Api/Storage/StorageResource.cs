
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Storage
{
    [PublicAPI]
    public class StorageResource
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("fileName")]
        public string FileName { get; set; }
    }
}