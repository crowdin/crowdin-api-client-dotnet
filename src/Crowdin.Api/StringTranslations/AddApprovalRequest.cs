
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class AddApprovalRequest
    {
        [JsonProperty("translationId")]
        public int TranslationId { get; set; }
    }
}