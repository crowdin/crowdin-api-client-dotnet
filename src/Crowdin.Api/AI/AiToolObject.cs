
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiToolObject
    {
        [JsonProperty("tool")]
        public AiTool? Tool { get; set; }
    }
}