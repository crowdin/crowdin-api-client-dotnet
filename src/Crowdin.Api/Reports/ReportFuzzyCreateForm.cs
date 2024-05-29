
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
        [SerializedValue("no_match")]
        NoMatch,
            
        [SerializedValue("perfect")]
        Perfect,
            
        [SerializedValue("100")]
        Option_100,
            
        [SerializedValue("99-95")]
        Option_99_95,
            
        [SerializedValue("94-90")]
        Option_94_90,
            
        [SerializedValue("89-80")]
        Option_89_80,
            
        [SerializedValue("approval")]
        Approval
    }
}