
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class TokensUsageRawDataGenerateAiReport : GenerateAiReport
    {
        public override AiReportType Type => AiReportType.TokensUsageRawData;

        [JsonProperty("schema")]
        public new GeneralSchema Schema { get; set; } = null!;

        [PublicAPI]
        public class GeneralSchema : AiReportSchemaBase
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