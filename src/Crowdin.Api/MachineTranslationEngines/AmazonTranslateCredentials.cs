
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.MachineTranslationEngines
{
    [PublicAPI]
    public class AmazonTranslateCredentials : IMtCredentialsForm
    {
        [JsonProperty("accessKey")]
        public string AccessKey { get; set; }
        
        [JsonProperty("secretKey")]
        public string SecretKey { get; set; }
    }
}