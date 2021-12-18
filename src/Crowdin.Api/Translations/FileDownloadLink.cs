
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class FileDownloadLink : DownloadLink
    {
        [JsonProperty("etag")]
        public string Etag { get; set; }
    }
}