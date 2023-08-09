
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Reports
{
    [PublicAPI]
    public class BaseRatesForm
    {
        [JsonProperty("fullTranslation")]
        public float FullTranslation { get; set; }
                
        [JsonProperty("proofread")]
        public float Proofread { get; set; }
    }
}