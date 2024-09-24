
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public abstract class GenerateAiReport
    {
        [JsonProperty("type")]
        public abstract AiReportType Type { get; }

        [JsonProperty("schema")]
        public AiReportSchemaBase Schema { get; set; }
    }
}