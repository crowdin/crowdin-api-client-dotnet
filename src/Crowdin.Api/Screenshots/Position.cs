
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Screenshots
{
    [PublicAPI]
    public class Position
    {
        [JsonProperty("x")]
        public int X { get; set; }
        
        [JsonProperty("y")]
        public int Y { get; set; }
        
        [JsonProperty("width")]
        public int Width { get; set; }
        
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}