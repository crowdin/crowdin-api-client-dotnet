
using System;
using System.Collections.Generic;
using System.ComponentModel;

using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class TranslationCostsPostEditingGenerateReportRequest : GenerateReportRequest
    {
        [JsonProperty("name")]
        public string Name => "translation-costs-pe";
        
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
            
#pragma warning disable CS8618
            [JsonProperty("baseRates")]
            public BaseRatesForm BaseRates { get; set; }
            
            [JsonProperty("individualRates")]
            public ICollection<IndividualRate> IndividualRates { get; set; }
            
            [JsonProperty("netRateSchemes")]
            public NetRateSchemes NetRateSchemes { get; set; }
#pragma warning restore CS8618
        }

        [PublicAPI]
        public class GeneralSchema : SchemaBase
        {
            [JsonProperty("groupBy")]
            public GroupingParameter? GroupBy { get; set; }
            
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
            
            [JsonProperty("languageId")]
            public string? LanguageId { get; set; }
            
            [JsonProperty("userIds")]
            public ICollection<int>? UserIds { get; set; }
            
            [JsonProperty("fileIds")]
            public ICollection<int>? FileIds { get; set; }
            
            [JsonProperty("directoryIds")]
            public ICollection<int>? DirectoryIds { get; set; }
            
            [JsonProperty("branchIds")]
            public ICollection<int>? BranchIds { get; set; }

            [PublicAPI]
            public enum GroupingParameter
            {
                [Description("user")]
                User,
                
                [Description("language")]
                Language
            }
        }

        [PublicAPI]
        public class ByTaskSchema : SchemaBase
        {
            [JsonProperty("taskId")]
            public int? TaskId { get; set; }
        }
        
        [PublicAPI]
        public class BaseRatesForm
        {
            [JsonProperty("fullTranslation")]
            public float FullTranslation { get; set; }

            [JsonProperty("proofread")]
            public float Proofread { get; set; }
        }

        [PublicAPI]
        public class IndividualRate
        {
#pragma warning disable CS8618
            [JsonProperty("languageIds")]
            public ICollection<string> LanguageIds { get; set; }

            [JsonProperty("userIds")]
            public ICollection<int> UserIds { get; set; }
#pragma warning restore CS8618

            [JsonProperty("fullTranslation")]
            public float FullTranslation { get; set; }

            [JsonProperty("proofread")]
            public float Proofread { get; set; }
        }

        [PublicAPI]
        public class NetRateSchemes
        {
#pragma warning disable CS8618
            [JsonProperty("tmMatch")]
            public ICollection<Match> TmMatch { get; set; }

            [JsonProperty("mtMatch")]
            public ICollection<Match> MtMatch { get; set; }

            [JsonProperty("suggestionMatch")]
            public ICollection<Match> SuggestionMatch { get; set; }
#pragma warning restore CS8618
        }

        [PublicAPI]
        public class Match
        {
            [JsonProperty("matchType")]
            public MatchType MatchType { get; set; }
            
            [JsonProperty("price")]
            public float Price { get; set; }
        }
        
        [PublicAPI]
        public enum MatchType
        {
            [Description("perfect")]
            Perfect,

            // ReSharper disable InconsistentNaming
            [Description("100")]
            Option_100,

            [Description("99-82")]
            Option_99_82,

            [Description("81-60")]
            Option_81_60
            // ReSharper restore InconsistentNaming
        }
    }
}