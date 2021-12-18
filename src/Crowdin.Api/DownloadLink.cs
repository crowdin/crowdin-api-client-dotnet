
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api
{
    [PublicAPI]
    public class DownloadLink
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("expireIn")]
        public DateTimeOffset ExpireIn { get; set; }
    }
}