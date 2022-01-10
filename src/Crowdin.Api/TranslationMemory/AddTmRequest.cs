
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class AddTmRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("groupId")]
        public int? GroupId { get; set; }
    }
}