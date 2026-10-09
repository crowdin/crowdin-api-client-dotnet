
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class AddApprovalRequest
    {
        [JsonProperty("translationId", NullValueHandling = NullValueHandling.Ignore)]
        public long? TranslationId { get; set; }

        [JsonProperty("correctionId", NullValueHandling = NullValueHandling.Ignore)]
        public long? CorrectionId { get; set; }
    }
}
