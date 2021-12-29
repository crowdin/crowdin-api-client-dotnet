
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class TranslationCostFuzzyModeGenerateReportRequest : GenerateReportRequest
    {
        [JsonProperty("name")]
        public string Name => "translation-costs";
        
        [JsonProperty("schema")]
        public SchemaBase Schema { get; set; }

        [PublicAPI]
        public class SchemaBase
        {
            [JsonProperty("mode")]
            public string Mode => "fuzzy";
            
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

        [PublicAPI]
        public class RegularSchema : SchemaBase
        {
            [JsonProperty("regularRates")]
            public ICollection<ReportFuzzyCreateForm>? RegularRates { get; set; }
            
            [JsonProperty("individualRates")]
            public ICollection<ReportFuzzyIndividualRatesForm>? IndividualRates { get; set; }
        }

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
        public abstract class StepType { }

        [PublicAPI]
        public class TranslateStepType : StepType
        {
            [JsonProperty("type")]
            public string Type => "Translate";

            [JsonProperty("mode")]
            public string Mode => "fuzzy";
            
            [JsonProperty("regularRates")]
            public ICollection<ReportFuzzyCreateForm>? RegularRates { get; set; }
            
            [JsonProperty("individualRates")]
            public ICollection<ReportFuzzyIndividualRatesForm>? IndividualRates { get; set; }
        }

        [PublicAPI]
        public class ProofreadStepType : StepType
        {
            [JsonProperty("type")]
            public string Type => "Proofread";

            [JsonProperty("mode")]
            public string Mode => "simple";
            
            [JsonProperty("regularRates")]
            public ICollection<ReportApprovalRate>? RegularRates { get; set; }
            
            [JsonProperty("individualRates")]
            public ICollection<ReportApprovalIndividualRates>? IndividualRates { get; set; }
        }

        #endregion
    }
}