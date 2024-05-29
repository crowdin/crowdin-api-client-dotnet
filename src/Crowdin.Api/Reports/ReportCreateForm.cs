
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
        [SerializedValue("no_match")]
        NoMatch,
        
        [SerializedValue("tm_match")]
        TmMatch,
        
        [SerializedValue("approval")]
        Approval
    }
}