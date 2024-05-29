
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
        [SerializedValue("name")]
        Name,
        
        [SerializedValue("currency")]
        Currency,
        
        [SerializedValue("unit")]
        Unit,
        
        [SerializedValue("mode")]
        Mode,
        
        [SerializedValue("config")]
        Config
    }
}