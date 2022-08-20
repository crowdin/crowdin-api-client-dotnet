
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ReportSettingsTemplatePatch : PatchEntry
    {
        [JsonProperty("path")]
        public ReportSettingsTemplatePatchPath Path { get; set; }
    }
    
    [PublicAPI]
    public enum ReportSettingsTemplatePatchPath
    {
        [Description("name")]
        Name,
        
        [Description("currency")]
        Currency,
        
        [Description("unit")]
        Unit,
        
        [Description("mode")]
        Mode,
        
        [Description("config")]
        Config
    }
}