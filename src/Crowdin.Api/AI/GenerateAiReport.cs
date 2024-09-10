
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public abstract class GenerateAiReport
    {
        [JsonProperty("type")]
        public abstract string Type { get; }
    }

    [PublicAPI]
    public class TokensUsageRawDataGenerateAiReport : GenerateAiReport
    {
        public override string Type => "tokens-usage-raw-data";

        [JsonProperty("schema")]
        public GeneralSchema Schema { get; set; } = null!; // TODO: multiple schemes in future?

        [PublicAPI]
        public class GeneralSchema
        {
            [JsonProperty("dateFrom")]
            public DateTimeOffset DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset DateTo { get; set; }
            
            [JsonProperty("format")]
            public AiReportFormat? Format { get; set; }
            
            [JsonProperty("projectIds")]
            public ICollection<int>? ProjectIds { get; set; }
            
            [JsonProperty("promptIds")]
            public ICollection<int>? PromptIds { get; set; }
            
            [JsonProperty("userIds")]
            public ICollection<int>? UserIds { get; set; }
        }
    }
}