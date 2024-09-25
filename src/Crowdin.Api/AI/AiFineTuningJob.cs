
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiFineTuningJob
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; } = null!;
        
        [JsonProperty("status")]
        public OperationStatus Status { get; set; }
        
        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("attributes")]
        public AttributesObject Attributes { get; set; } = null!;
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
        
        [JsonProperty("startedAt")]
        public DateTimeOffset StartedAt { get; set; }
        
        [JsonProperty("finishedAt")]
        public DateTimeOffset FinishedAt { get; set; }

        [PublicAPI]
        public class AttributesObject
        {
            [JsonProperty("dryRun")]
            public bool DryRun { get; set; }
            
            [JsonProperty("hyperParameters")]
            public AiHyperParameters? HyperParameters { get; set; }

            [JsonProperty("trainingOptions")]
            public AiTrainingOptions TrainingOptions { get; set; } = null!;
            
            [JsonProperty("validationOptions")]
            public AiValidationOptions? ValidationOptions { get; set; }
            
            [JsonProperty("fineTunedModel")]
            public string? FineTunedModel { get; set; }
            
            [JsonProperty("trainedTokensCount")]
            public int? TrainingTokensCount { get; set; }
            
            [JsonProperty("metadata")]
            public MetadataObject? Metadata { get; set; }

            [PublicAPI]
            public class MetadataObject
            {
                [JsonProperty("cost")]
                public float? Cost { get; set; }

                [JsonProperty("costCurrency")]
                public string? CostCurrency { get; set; }
            }
        }
    }
}