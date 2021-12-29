
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class GroupTranslationCostGenerateGroupReportRequest : GenerateGroupReportRequest
    {
        [JsonProperty("name")]
        public string Name => "group-translation-costs";
        
        [JsonProperty("schema")]
        public RequestSchema Schema { get; set; }

        [PublicAPI]
        public class RequestSchema
        {
            [JsonProperty("projectIds")]
            public ICollection<int>? ProjectIds { get; set; }
            
            [JsonProperty("unit")]
            public ReportUnit? Unit { get; set; }
            
            [JsonProperty("currency")]
            public ReportCurrency? Currency { get; set; }
            
            [JsonProperty("format")]
            public ReportFormat? Format { get; set; }
            
            [JsonProperty("groupBy")]
            public ReportGroupingMode? GroupBy { get; set; }
            
            [JsonProperty("useIndividualRates")]
            public bool? UseIndividualRates { get; set; }
            
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
            
            [JsonProperty("userIds")]
            public ICollection<int>? UserIds { get; set; }
        }
    }
}