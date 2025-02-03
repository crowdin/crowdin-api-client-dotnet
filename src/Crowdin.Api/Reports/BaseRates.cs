
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    public class BaseRates
    {
        [JsonProperty("fullTranslation")]
        public float FullTranslation { get; set; }
                
        [JsonProperty("proofread")]
        public float Proofread { get; set; }
    }
}