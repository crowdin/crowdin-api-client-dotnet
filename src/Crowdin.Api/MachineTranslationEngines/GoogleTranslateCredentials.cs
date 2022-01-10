
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public class GoogleTranslateCredentials : IMtCredentialsForm
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
    }
}