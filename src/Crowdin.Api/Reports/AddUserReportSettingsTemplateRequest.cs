
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class AddUserReportSettingsTemplateRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("currency")]
        public ReportCurrency Currency { get; set; }
        
        [JsonProperty("unit")]
        public ReportUnit Unit { get; set; }
        
        [JsonProperty("config")]
        public ConfigurationForm Config { get; set; }
        
        [PublicAPI]
        public class ConfigurationForm
        {
            [JsonProperty("baseRates")]
            public BaseRatesForm BaseRates { get; set; }

            [JsonProperty("individualRates")]
            public ICollection<IndividualRateForm> IndividualRates { get; set; }

            [JsonProperty("netRateSchemes")]
            public NetRateSchemesForm NetRateSchemes { get; set; }

            #region Rates

            [PublicAPI]
            public class IndividualRateForm
            {
                [JsonProperty("languageIds")]
                public ICollection<string> LanguageIds { get; set; }
            
                [JsonProperty("fullTranslation")]
                public float FullTranslation { get; set; }
                
                [JsonProperty("proofread")]
                public float Proofread { get; set; }
            }

            [PublicAPI]
            public class NetRateSchemesForm
            {
                [JsonProperty("tmMatch")]
                public ICollection<Match> TmMatch { get; set; }
            
                [JsonProperty("mtMatch")]
                public ICollection<Match> MtMatch { get; set; }
            
#nullable enable
                [JsonProperty("aiMatch")]
                public ICollection<Match>? AiMatch { get; set; }
#nullable disable
            
                [JsonProperty("suggestionMatch")]
                public ICollection<Match> SuggestionMatch { get; set; }
            }

            #endregion
        }
    }
}