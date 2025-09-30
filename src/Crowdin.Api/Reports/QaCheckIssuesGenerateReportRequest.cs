
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class QaCheckIssuesGenerateReportRequest : GenerateReportRequest
    {
        [JsonProperty("name")]
        public string Name => "qa-check-issues";

        [JsonProperty("schema")]
        public SchemaObject Schema { get; set; } = null!;

        [PublicAPI]
        public class SchemaObject
        {
            [JsonProperty("format")]
            public ReportFormat? Format { get; set; }
            
            [JsonProperty("languageId")]
            public string? LanguageId { get; set; }
            
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
        }
    }
}