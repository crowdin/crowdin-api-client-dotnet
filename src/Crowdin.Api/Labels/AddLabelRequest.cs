
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Labels
{
    [PublicAPI]
    public class AddLabelRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}