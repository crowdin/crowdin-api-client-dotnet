
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class AiProviderModelResource
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}