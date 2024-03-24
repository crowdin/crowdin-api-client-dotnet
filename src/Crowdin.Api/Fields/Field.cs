using System;
using Newtonsoft.Json;

namespace Crowdin.Api.Fields
{
    public class Field
    {
        [JsonProperty("id")]
        public int Id { get; set; }

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
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}