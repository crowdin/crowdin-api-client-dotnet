
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public class CustomMtTranslateCredentials : IMtCredentialsForm
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}