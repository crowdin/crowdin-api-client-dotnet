
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class AddGlossaryRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("groupId")]
        public int? GroupId { get; set; }
    }
}