
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api
{
    [PublicAPI]
    public abstract class PatchEntry
    {
        [JsonProperty("op")]
        public PatchOperation Operation { get; set; }
        
        [JsonProperty("value")]
        public object Value { get; set; }
    }
}