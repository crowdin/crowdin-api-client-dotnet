using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiModelPrice
    {
        [JsonProperty("input")]
        public decimal Input { get; set; }

        [JsonProperty("output")]
        public decimal Output { get; set; }
    }
}