
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ReportFuzzyCreateForm
    {
        [JsonProperty("mode")]
        public ReportFuzzyCreateMode? Mode { get; set; }
        
        [JsonProperty("value")]
        public float? Value { get; set; }
    }

    [PublicAPI]
    public enum ReportFuzzyCreateMode
    {
        [Description("no_match")]
        NoMatch,
            
        [Description("perfect")]
        Perfect,
            
        [Description("100")]
        Option_100,
            
        [Description("99-95")]
        Option_99_95,
            
        [Description("94-90")]
        Option_94_90,
            
        [Description("89-80")]
        Option_89_80,
            
        [Description("approval")]
        Approval
    }
}