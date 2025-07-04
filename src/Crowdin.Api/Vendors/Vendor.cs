
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Vendors
{
    [PublicAPI]
    public class Vendor
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("status")]
        public VendorStatus Status { get; set; }
    }
}