
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    [Obsolete(MessageTexts.DeprecatedModel)]
    public class GroupTranslationCostGenerateGroupReportRequest : GenerateGroupReportRequest
    {
        [JsonProperty("name")]
        public string Name => "group-translation-costs";
        
        [JsonProperty("schema")]
#pragma warning disable CS8618
        public RequestSchema Schema { get; set; }
#pragma warning restore CS8618

        [PublicAPI]
        public class RequestSchema
        {
            [JsonProperty("projectIds")]
            public ICollection<long>? ProjectIds { get; set; }
            
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
            public ICollection<long>? UserIds { get; set; }
        }
    }
}