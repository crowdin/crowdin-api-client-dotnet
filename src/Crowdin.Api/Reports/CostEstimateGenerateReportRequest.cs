
using System;
using System.Collections.Generic;
using System.ComponentModel;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    [Obsolete(MessageTexts.DeprecatedModel)]
    public class CostEstimateGenerateReportRequest : GenerateReportRequest
    {
        [JsonProperty("name")]
        public string Name => "costs-estimation";
        
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
        }

        [PublicAPI]
        public abstract class GeneralSchemaBase : SchemaBase
        {
            [JsonProperty("languageId")]
            public string? LanguageId { get; set; }
            
            [JsonProperty("fileIds")]
            public ICollection<int>? FileIds { get; set; }
            
            [JsonProperty("directoryIds")]
            public ICollection<int>? DirectoryIds { get; set; }
            
            [JsonProperty("branchIds")]
            public ICollection<int>? BranchIds { get; set; }
            
            [JsonProperty("dateFrom")]
            public DateTimeOffset? DateFrom { get; set; }
            
            [JsonProperty("dateTo")]
            public DateTimeOffset? DateTo { get; set; }
            
            [JsonProperty("labelIds")]
            public ICollection<int>? LabelIds { get; set; }
            
            [JsonProperty("labelIncludeType")]
            public ReportLabelIncludeType? LabelIncludeType { get; set; }
        }

        [PublicAPI]
        public abstract class ByTaskSchemaBase : SchemaBase
        {
            [JsonProperty("taskId")]
            public int? TaskId { get; set; }
        }

        #region Regular

        [PublicAPI]
        public class GeneralSchema : GeneralSchemaBase
        {
            [JsonProperty("mode")]
            public string Mode => "simple";
        }
        
        [PublicAPI]
        public class ByTaskSchema : ByTaskSchemaBase
        {
            [JsonProperty("regularRates")]
            public ICollection<ReportCreateForm>? RegularRates { get; set; }
            
            [JsonProperty("individualRates")]
            public ICollection<ReportIndividualRatesForm>? IndividualRates { get; set; }
        }

        #endregion

        #region Enterprise

        [PublicAPI]
        public class EnterpriseGeneralSchema : GeneralSchemaBase
        {
            [JsonProperty("stepTypes")]
            public ICollection<StepType>? StepTypes { get; set; }
        }

        [PublicAPI]
        public class EnterpriseByTaskSchema : ByTaskSchemaBase
        {
            [JsonProperty("stepTypes")]
            public ICollection<StepType>? StepTypes { get; set; }
        }

        #endregion
        
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
                public string Mode => "Proofread";
                    
                [JsonProperty("value")]
                public float? Value { get; set; }
            }

            [PublicAPI]
            public class IndividualRate
            {
                [JsonProperty("languageIdsTo")]
                public ICollection<string>? LanguageIdsTo { get; set; }
                    
                [JsonProperty("rates")]
                public ICollection<ProofreadRate>? Rates { get; set; }
            }
        }

        #endregion
    }
}