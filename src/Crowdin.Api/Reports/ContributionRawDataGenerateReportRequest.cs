
using System;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ContributionRawDataGenerateReportRequest : GenerateReportRequest
    {
        [JsonProperty("name")]
        public string Name => "contribution-raw-data";
        
        [JsonProperty("schema")]
#pragma warning disable CS8618
        public RequestSchema Schema { get; set; }
#pragma warning restore CS8618

        [PublicAPI]
        public class RequestSchema
        {
            [JsonProperty("mode")]
            public ContributionReportMode Mode { get; set; }
            
            [JsonProperty("unit")]
            public ReportUnit? Unit { get; set; }
            
            [JsonProperty("languageId")]
            public string? LanguageId { get; set; }
            
            [JsonProperty("userId")]
            public string? UserId { get; set; }
            
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
        }
    }

    [PublicAPI]
    public enum ContributionReportMode
    {
        [SerializedValue("translations")]
        Translations,
        
        [SerializedValue("approvals")]
        Approvals,
        
        [SerializedValue("votes")]
        Votes
    }
}