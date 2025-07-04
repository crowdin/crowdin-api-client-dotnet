
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class UserReportSettingsTemplate
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("currency")]
        public ReportCurrency Currency { get; set; }

        [JsonProperty("unit")]
        public ReportUnit Unit { get; set; }
        
        [JsonProperty("config")]
        public Configuration Config { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [PublicAPI]
        public class Configuration
        {
            [JsonProperty("baseRates")]
            public BaseRates BaseRates { get; set; }
            
            [JsonProperty("individualRates")]
            public IndividualRate[] IndividualRates { get; set; }
            
            [JsonProperty("netRateSchemes")]
            public NetRateSchemesData NetRateSchemes { get; set; }
            
            [PublicAPI]
            public class IndividualRate
            {
                [JsonProperty("languageIds")]
                public string[] LanguageIds { get; set; }
            
                [JsonProperty("userIds")]
                public long[] UserIds { get; set; }
            
                [JsonProperty("fullTranslation")]
                public float FullTranslation { get; set; }
            
                [JsonProperty("proofread")]
                public float Proofread { get; set; }
            }
            
            [PublicAPI]
            public class NetRateSchemesData
            {
                [JsonProperty("tmMatch")]
                public Match[] TmMatch { get; set; }
            
                [JsonProperty("mtMatch")]
                public Match[] MtMatch { get; set; }
            
                [JsonProperty("aiMatch")]
                public Match[] AiMatch { get; set; }
            
                [JsonProperty("suggestionMatch")]
                public Match[] SuggestionMatch { get; set; }
            }
        }
    }
}