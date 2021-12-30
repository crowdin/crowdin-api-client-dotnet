
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ReportCreateForm
    {
        [JsonProperty("mode")]
        public ReportCreateMode? Mode { get; set; }
        
        [JsonProperty("value")]
        public float? Value { get; set; }
    }
    
    [PublicAPI]
    public enum ReportCreateMode
    {
        [Description("no_match")]
        NoMatch,
        
        [Description("tm_match")]
        TmMatch,
        
        [Description("approval")]
        Approval
    }
}