
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public class MtEngine
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("groupId")]
        public int GroupId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("credentials")]
        public IDictionary<string, int> Credentials { get; set; }
        
        [JsonProperty("projectIds")]
        public int[] ProjectIds { get; set; }
    }
}