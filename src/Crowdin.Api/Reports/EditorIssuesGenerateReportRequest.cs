
using System;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Issues;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class EditorIssuesGenerateReportRequest : GenerateReportRequest
    {
        [JsonProperty("name")]
        public string Name => "editor-issues";
        
        [JsonProperty("schema")]
        public SchemaObject Schema { get; set; }

        [PublicAPI]
        public class SchemaObject
        {
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
            
            [JsonProperty("format")]
            public ReportFormat? Format { get; set; }
            
            [JsonProperty("issueType")]
            public IssueType? IssueType { get; set; }
        }
    }
}