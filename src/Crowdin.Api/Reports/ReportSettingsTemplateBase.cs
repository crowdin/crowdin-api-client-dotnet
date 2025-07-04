
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public abstract class ReportSettingsTemplateBase
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618

        [JsonProperty("currency")]
        public ReportCurrency Currency { get; set; }

        [JsonProperty("unit")]
        public ReportUnit Unit { get; set; }

        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }

        [JsonProperty("mode")]
        public ReportSettingsTemplateMode Mode { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    [PublicAPI]
    public class ReportSettingsTemplateSimple : ReportSettingsTemplateBase
    {
#pragma warning disable CS8618

        [JsonProperty("config")]
        public ReportSettingsSimpleConfig Config { get; set; }

#pragma warning restore CS8618
    }

    [PublicAPI]
    public class ReportSettingsTemplateFuzzy : ReportSettingsTemplateBase
    {
#pragma warning disable CS8618

        [JsonProperty("config")]
        public ReportSettingsFuzzyConfig Config { get; set; }

#pragma warning restore CS8618
    }
}
