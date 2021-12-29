
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class ReportApprovalRate
    {
        [JsonProperty("mode")]
        public string Mode => "approval";
            
        [JsonProperty("value")]
        public float? Value { get; set; }
    }
}