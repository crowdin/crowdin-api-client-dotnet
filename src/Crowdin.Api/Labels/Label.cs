
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Labels
{
    [PublicAPI]
    public class Label
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("isSystem")]
        public bool IsSystem { get; set; }
    }
}