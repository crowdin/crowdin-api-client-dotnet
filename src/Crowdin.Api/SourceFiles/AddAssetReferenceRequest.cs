using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class AddAssetReferenceRequest
    {
        [JsonProperty("storageId")]
        public long StorageId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
