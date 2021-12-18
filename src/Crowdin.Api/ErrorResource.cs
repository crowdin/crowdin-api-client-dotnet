
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api
{
    [PublicAPI]
    public class ErrorResource
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        
        [JsonProperty("errors")]
        public AttributeError[] Errors { get; set; }
    }

    [PublicAPI]
    public class AttributeError
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}