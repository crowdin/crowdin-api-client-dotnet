
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiHyperParameters
    {
        [JsonProperty("batchSize")]
        public long? BatchSize { get; set; }
        
        [JsonProperty("learningRateMultiplier")]
        public float? LearningRateMultiplier { get; set; }
        
        [JsonProperty("nEpochs")]
        public long? NEpochs { get; set; }
    }
}