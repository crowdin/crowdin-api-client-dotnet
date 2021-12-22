
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Screenshots
{
    [PublicAPI]
    public class Size
    {
        [JsonProperty("width")]
        public int Width { get; set; }
        
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}