
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Labels
{
    [PublicAPI]
    public class Label
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}