
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class GroupSourceContentUpdatesGenerateGroupReportRequest : GenerateGroupReportRequest
    {
        [JsonProperty("name")]
        public string Name => "group-source-content-updates";

        [JsonProperty("schema")]
        public SchemaObject Schema { get; set; } = null!;

        [PublicAPI]
        public class SchemaObject
        {
            [JsonProperty("unit")]
            public ReportUnit? Unit { get; set; }
            
            [JsonProperty("format")]
            public ReportFormat? Format { get; set; }
            
            [JsonProperty("projectIds")]
            public ICollection<long>? ProjectIds { get; set; }
            
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
        }
    }
}