
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ReportSettingsSimpleConfig
    {
#pragma warning disable CS8618

        [JsonProperty("regularRates")]
        public RegularRate[] RegularRates { get; set; }

        [JsonProperty("individualRates")]
        public IndividualRate[] IndividualRates { get; set; }

#pragma warning restore CS8618

        #region Rates

        [PublicAPI]
        public enum RateMode
        {
            [SerializedValue("no_match")]
            NoMatch,

            [SerializedValue("tm_match")]
            TmMatch,

            [SerializedValue("approval")]
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
            public int[]? UserIds { get; set; }

            [JsonProperty("rates")]
            public ICollection<RegularRate>? Rates { get; set; }
        }

        #endregion
    }
}
