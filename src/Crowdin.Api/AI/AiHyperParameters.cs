
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiHyperParameters
    {
        [JsonProperty("batchSize")]
        public int? BatchSize { get; set; }
        
        [JsonProperty("learningRateMultiplier")]
        public float? LearningRateMultiplier { get; set; }
        
        [JsonProperty("nEpochs")]
        public int? NEpochs { get; set; }
    }
}