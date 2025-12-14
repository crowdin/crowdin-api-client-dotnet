using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiModelModalities
    {
        [JsonProperty("input")]
        public AiModelModalityDetails Input { get; set; }

        [JsonProperty("output")]
        public AiModelModalityDetails Output { get; set; }
    }
}