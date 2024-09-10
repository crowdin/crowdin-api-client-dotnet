
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public class CloneAiPromptRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}