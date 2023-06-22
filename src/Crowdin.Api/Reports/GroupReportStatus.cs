
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class GroupReportStatus
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("status")]
        public OperationStatus Status { get; set; }
        
        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("attributes")]
        public ReportAttributes Attributes { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
        
        [JsonProperty("startedAt")]
        public DateTimeOffset? StartedAt { get; set; }
        
        [JsonProperty("finishedAt")]
        public DateTimeOffset? FinishedAt { get; set; }

        [PublicAPI]
        public class ReportAttributes
        {
            [JsonProperty("format")]
            public ReportFormat Format { get; set; }
            
            [JsonProperty("reportName")]
            public string ReportName { get; set; }
            
            [JsonProperty("projectIds")]
            public ICollection<int> ProjectIds { get; set; }
            
            [JsonProperty("schema")]
            public object Schema { get; set; }
        }
    }
}