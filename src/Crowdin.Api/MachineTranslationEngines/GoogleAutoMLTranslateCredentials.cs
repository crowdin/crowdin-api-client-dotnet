
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    // ReSharper disable once InconsistentNaming
    public class GoogleAutoMLTranslateCredentials : IMtCredentialsForm
    {
        [JsonProperty("credentials")]
        public string Credentials { get; set; }
    }
}