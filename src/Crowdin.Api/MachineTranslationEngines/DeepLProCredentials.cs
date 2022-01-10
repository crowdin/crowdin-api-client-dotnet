
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public class DeepLProCredentials : IMtCredentialsForm
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }
    }
}