using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiModelFeatures
    {
        [JsonProperty("streaming")]
        public bool Streaming { get; set; }

        [JsonProperty("structuredOutput")]
        public bool StructuredOutput { get; set; }

        [JsonProperty("functionCalling")]
        public bool FunctionCalling { get; set; }
    }
}