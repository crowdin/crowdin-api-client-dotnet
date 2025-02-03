
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class UserReportSettingsTemplatePatch : PatchEntry
    {
        [JsonProperty("path")]
        public UserReportSettingsTemplatePatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum UserReportSettingsTemplatePatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/currency")]
        Currency,
        
        [Description("/unit")]
        Unit,
        
        [Description("/config")]
        Config
    }
}