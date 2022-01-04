
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public class AddMtEngineRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("type")]
        public MtEngineType Type { get; set; }
        
        [JsonProperty("credentials")]
        public IMtCredentialsForm Credentials { get; set; }
        
        [JsonProperty("groupId")]
        public int? GroupId { get; set; }
    }
}