
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public class MicrosoftTranslateCredentials : IMtCredentialsForm
    {
        [JsonProperty("apiKey")]
#pragma warning disable CS8618
        public string ApiKey { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("model")]
        public string? Model { get; set; }
    }
}