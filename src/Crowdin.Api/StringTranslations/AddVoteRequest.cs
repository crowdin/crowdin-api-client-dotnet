
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class AddVoteRequest
    {
        [JsonProperty("mark")]
        public TranslationVoteMark Mark { get; set; }
        
        [JsonProperty("translationId")]
        public long? TranslationId { get; set; }
    }
}