
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class CreateAiPromptFineTuningJobRequest
    {
        [JsonProperty("dryRun")]
        public bool? DryRun { get; set; }
        
        // ReSharper disable once StringLiteralTypo -> reviewed
        [JsonProperty("hyperparameters")]
        public AiHyperParameters? HyperParameters { get; set; }

        [JsonProperty("trainingOptions")]
        public AiTrainingOptions TrainingOptions { get; set; } = null!;
        
        [JsonProperty("validationOptions")]
        public AiValidationOptions? ValidationOptions { get; set; }
    }
}