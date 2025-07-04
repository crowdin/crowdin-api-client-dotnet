
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class CostEstimationPostEditingGenerateReportRequest : GenerateReportRequest
    {
        [JsonProperty("name")]
        public string Name => "costs-estimation-pe";
        
        [JsonProperty("schema")]
#pragma warning disable CS8618
        public SchemaBase Schema { get; set; }
#pragma warning restore CS8618

        [PublicAPI]
        public abstract class SchemaBase
        {
            [JsonProperty("unit")]
            public ReportUnit? Unit { get; set; }
            
            [JsonProperty("currency")]
            public ReportCurrency? Currency { get; set; }
            
            [JsonProperty("format")]
            public ReportFormat? Format { get; set; }
            
            [JsonProperty("calculateInternalMatches")]
            public bool? CalculateInternalMatches { get; set; }
            
            [JsonProperty("includePreTranslatedStrings")]
            public bool? IncludePreTranslatedStrings { get; set; }
        }

        [PublicAPI]
        public class GeneralSchema : SchemaBase
        {
#pragma warning disable CS8618
            [JsonProperty("baseRates")]
            public BaseRatesForm BaseRates { get; set; }
            
            [JsonProperty("individualRates")]
            public ICollection<IndividualRate> IndividualRates { get; set; }
            
            [JsonProperty("netRateSchemes")]
            public NetRateSchemes NetRateSchemes { get; set; }
#pragma warning restore CS8618

            [JsonProperty("languageId")]
            public string? LanguageId { get; set; }
            
            [JsonProperty("fileIds")]
            public ICollection<long>? FileIds { get; set; }
            
            [JsonProperty("directoryIds")]
            public ICollection<long>? DirectoryIds { get; set; }
            
            [JsonProperty("branchIds")]
            public ICollection<long>? BranchIds { get; set; }
            
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
            
            [JsonProperty("labelIds")]
            public ICollection<long>? LabelIds { get; set; }
            
            [JsonProperty("labelIncludeType")]
            public ReportLabelIncludeType? LabelIncludeType { get; set; }
        }

        [PublicAPI]
        public class ByTaskSchema : SchemaBase
        {
            [JsonProperty("baseRates")]
            public BaseRatesForm? BaseRates { get; set; }
            
            [JsonProperty("individualRates")]
            public ICollection<IndividualRate>? IndividualRates { get; set; }
            
            [JsonProperty("netRateSchemes")]
            public NetRateSchemes? NetRateSchemes { get; set; }
            
            [JsonProperty("taskId")]
            public long? TaskId { get; set; }
        }

        [PublicAPI]
        public class IndividualRate
        {
#pragma warning disable CS8618
            [JsonProperty("languageIds")]
            public ICollection<string> LanguageIds { get; set; }

            [JsonProperty("userIds")]
            public ICollection<long> UserIds { get; set; }
#pragma warning restore CS8618
            
            [JsonProperty("fullTranslation")]
            public float FullTranslation { get; set; }
            
            [JsonProperty("proofread")]
            public float Proofread { get; set; }
        }

        [PublicAPI]
        public class NetRateSchemes
        {
            [JsonProperty("tmMatch")]
#pragma warning disable CS8618
            public ICollection<Match> TmMatch { get; set; }
#pragma warning restore CS8618
        }
    }
}