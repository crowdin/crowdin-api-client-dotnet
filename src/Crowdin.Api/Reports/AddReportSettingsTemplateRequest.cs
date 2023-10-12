
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public abstract class AddReportSettingsTemplateRequest
    {
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618

        [JsonProperty("currency")]
        public ReportCurrency Currency { get; set; }

        [JsonProperty("unit")]
        public ReportUnit Unit { get; set; }

        [JsonProperty("isPublic")]
        public ReportIsPublic IsPublic { get; set; }
    }

    [PublicAPI]
    public class AddReportSettingsTemplateSimpleModeRequest : AddReportSettingsTemplateRequest
    {
        [JsonProperty("mode")]
        public ReportSettingsTemplateMode Mode => ReportSettingsTemplateMode.Simple;

        [JsonProperty("config")]
#pragma warning disable CS8618
        public ReportSettingsSimpleConfig Config { get; set; }
#pragma warning restore CS8618
    }

    [PublicAPI]
    public class AddReportSettingsTemplateFuzzyModeRequest : AddReportSettingsTemplateRequest
    {
        [JsonProperty("mode")]
        public ReportSettingsTemplateMode Mode => ReportSettingsTemplateMode.Fuzzy;

        [JsonProperty("config")]
#pragma warning disable CS8618
        public ReportSettingsFuzzyConfig Config { get; set; }
#pragma warning restore CS8618
    }
}
