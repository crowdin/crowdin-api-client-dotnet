
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ProjectMembersGenerateReportRequest : GenerateReportRequest
    {
        [JsonProperty("name")]
        public string Name => "project-members";
        
        [JsonProperty("schema")]
        public SchemaObject Schema { get; set; }

        [PublicAPI]
        public class SchemaObject
        {
            [JsonProperty("format")]
            public ReportFormat? Format { get; set; }
            
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
        }
    }
}