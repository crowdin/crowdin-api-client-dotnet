
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationStatus
{
    [PublicAPI]
    public class FileProgressResource : ProgressResource
    {
        [JsonProperty("eTag")]
        public string Etag { get; set; }
    }
}