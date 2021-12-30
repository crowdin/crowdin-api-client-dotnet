
using System;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class TranslationCostGenerateReportRequest : GenerateReportRequest
    {
        [JsonProperty("name")]
        public string Name => "translation-costs";
        
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
            
            [JsonProperty("groupBy")]
            public ReportGroupingMode? GroupBy { get; set; }

            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
            
            [JsonProperty("languageId")]
            public string? LanguageId { get; set; }
            
            [JsonProperty("userIds")]
            public ICollection<int>? UserIds { get; set; }
        }

        #region Regular

        [PublicAPI]
        public class RegularSchema : SchemaBase
        {
            [JsonProperty("mode")]
            public string? Mode { get; set; }
            
            [JsonProperty("regularRates")]
            public ICollection<ReportCreateForm>? RegularRates { get; set; }
            
            [JsonProperty("individualRates")]
            public ICollection<ReportIndividualRatesForm>? IndividualRates { get; set; }
        }
        
        [PublicAPI]
        public class ReportIndividualRatesForm
        {
            [JsonProperty("languageIds")]
            public ICollection<string>? LanguageIds { get; set; }
            
            [JsonProperty("userIds")]
            public ICollection<int>? UserIds { get; set; }
            
            [JsonProperty("rates")]
            public ICollection<ReportCreateForm>? Rates { get; set; }
        }

        #endregion

        #region Enterprise

        [PublicAPI]
        public class EnterpriseSchema : SchemaBase
        {
            [JsonProperty("useIndividualRates")]
            public bool? UseIndividualRates { get; set; }
            
            [JsonProperty("stepTypes")]
            public ICollection<StepType>? StepTypes { get; set; }
        }

        #region Step types

        [PublicAPI]
        public abstract class StepType
        {
            [JsonProperty("mode")]
            public string Mode => "simple";
        }

        [PublicAPI]
        public class TranslateStepType : StepType
        {
            [JsonProperty("type")]
            public string Type => "Translate";
                
            [JsonProperty("regularRates")]
            public ICollection<RegularRate>? RegularRates { get; set; }
                
            [JsonProperty("individualRates")]
            public ICollection<IndividualRate>? IndividualRates { get; set; }

            #region Rates

            [PublicAPI]
            public class RegularRate
            {
                [JsonProperty("mode")]
                public RateMode? Mode { get; set; }
                    
                [JsonProperty("value")]
                public float? Value { get; set; }
            }

            [PublicAPI]
            public enum RateMode
            {
                [Description("no_match")]
                NoMatch,
                    
                [Description("tm_match")]
                TmMatch
            }

            [PublicAPI]
            public class IndividualRate
            {
                [JsonProperty("languageIdsTo")]
                public ICollection<string>? LanguageIdsTo { get; set; }
                    
                [JsonProperty("rates")]
                public ICollection<RegularRate>? Rates { get; set; }
            }

            #endregion
        }

        [PublicAPI]
        public class ProofreadStepType : StepType
        {
            [JsonProperty("type")]
            public string Type => "Proofread";
            
            [JsonProperty("regularRates")]
            public ICollection<ProofreadRate>? RegularRates { get; set; }
                
            [JsonProperty("individualRates")]
            public ICollection<IndividualRate>? IndividualRates { get; set; }
            
            [PublicAPI]
            public class ProofreadRate
            {
                [JsonProperty("mode")]
                public string Mode => "proofread";
                    
                [JsonProperty("value")]
                public float? Value { get; set; }
            }
            
            [PublicAPI]
            public class IndividualRate
            {
                [JsonProperty("languageIdsTo")]
                public ICollection<string>? LanguageIdsTo { get; set; }
                
                [JsonProperty("userIds")]
                public ICollection<int>? UserIds { get; set; }

                [JsonProperty("rates")]
                public ICollection<ProofreadRate>? Rates { get; set; }
            }
        }

        #endregion

        #endregion
    }
}