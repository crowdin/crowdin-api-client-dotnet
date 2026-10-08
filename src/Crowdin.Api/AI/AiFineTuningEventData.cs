#nullable enable

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiFineTuningEventData
    {
        [JsonProperty("step")]
        public int Step { get; set; }

        [JsonProperty("totalSteps")]
        public int TotalSteps { get; set; }

        [JsonProperty("trainingLoss")]
        public double TrainingLoss { get; set; }

        [JsonProperty("validationLoss")]
        public double? ValidationLoss { get; set; }

        [JsonProperty("fullValidationLoss")]
        public double? FullValidationLoss { get; set; }
    }
}
