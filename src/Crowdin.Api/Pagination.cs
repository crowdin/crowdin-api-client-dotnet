
using Newtonsoft.Json;

namespace Crowdin.Api
{
    public class Pagination
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }
        
        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
}