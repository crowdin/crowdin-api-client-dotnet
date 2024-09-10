
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiToolFunction
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        
        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("parameters")]
        public object? Parameters { get; set; }
    }
}