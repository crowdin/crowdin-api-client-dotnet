
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public class WatsonTranslateCredentials : IMtCredentialsForm
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
        
        [JsonProperty("endpoint")]
        public string EndpointUrl { get; set; }
    }
}