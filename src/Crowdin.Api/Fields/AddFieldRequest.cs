using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Fields
{
    [PublicAPI]
    public class AddFieldRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("type")]
        public FieldType Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("entities")]
        public FieldEntity[] Entities { get; set; }

        [JsonProperty("config")]
        public FieldConfig Config { get; set; }

    }
}