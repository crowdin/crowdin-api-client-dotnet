
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class GroupTopMembersGenerateGroupReportRequest : GenerateGroupReportRequest
    {
        [JsonProperty("name")]
        public string Name => "group-top-members";
        
        [JsonProperty("schema")]
        public RequestSchema Schema { get; set; }

        [PublicAPI]
        public class RequestSchema
        {
            [JsonProperty("projectIds")]
            public ICollection<int>? ProjectIds { get; set; }
            
            [JsonProperty("unit")]
            public ReportUnit? Unit { get; set; }
            
            [JsonProperty("languageId")]
            public string? LanguageId { get; set; }
            
            [JsonProperty("format")]
            public ReportFormat? Format { get; set; }

            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
        }
    }
}