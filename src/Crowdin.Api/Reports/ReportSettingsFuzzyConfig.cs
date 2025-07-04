
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ReportSettingsFuzzyConfig
    {
#pragma warning disable CS8618

        [JsonProperty("regularRates")]
        public ICollection<RegularRate> RegularRates { get; set; }

        [JsonProperty("individualRates")]
        public ICollection<IndividualRate> IndividualRates { get; set; }

#pragma warning restore CS8618

        #region Rates

        [PublicAPI]
        public enum RateMode
        {
            [Description("no_match")]
            NoMatch,

            [Description("perfect")]
            Perfect,

            // ReSharper disable InconsistentNaming
            [Description("100")]
            Option_100,

            [Description("99-95")]
            Option_99_95,

            [Description("94-90")]
            Option_94_90,

            [Description("89-80")]
            Option_89_80,
            // ReSharper restore InconsistentNaming

            [Description("approval")]
            Approval
        }

        [PublicAPI]
        public class RegularRate
        {
            [JsonProperty("mode")]
            public RateMode? Mode { get; set; }

            [JsonProperty("value")]
            public float? Value { get; set; }
        }

        [PublicAPI]
        public class IndividualRate
        {
            [JsonProperty("languageIds")]
            public ICollection<string>? LanguageIds { get; set; }

            [JsonProperty("userIds")]
            public ICollection<long>? UserIds { get; set; }

            [JsonProperty("rates")]
            public ICollection<RegularRate>? Rates { get; set; }
        }

        #endregion
    }
}
