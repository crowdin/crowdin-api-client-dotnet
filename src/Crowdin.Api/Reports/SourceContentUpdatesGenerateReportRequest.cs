
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class SourceContentUpdatesGenerateReportRequest : GenerateReportRequest
    {
        [JsonProperty("name")]
        public string Name => "source-content-updates";
        
        [JsonProperty("schema")]
        public SchemaObject Schema { get; set; }
        
        [PublicAPI]
        public class SchemaObject
        {
            [JsonProperty("unit")]
            public ReportUnit? Unit { get; set; }
            
            [JsonProperty("format")]
            public ReportFormat? Format { get; set; }
            
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
        }
    }
}