
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiTool
    {
        [JsonProperty("type")]
        public AiToolType Type { get; set; }

        [JsonProperty("function")]
        public AiToolFunction Function { get; set; } = null!;
    }
}