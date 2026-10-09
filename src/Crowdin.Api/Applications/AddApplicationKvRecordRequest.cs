#nullable enable

using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class AddApplicationKvRecordRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; } = null!;

        [JsonProperty("value")]
        public JToken Value { get; set; } = null!;

        [JsonProperty("secret")]
        public bool? Secret { get; set; } = false;

        [JsonProperty("ttl")]
        public int? Ttl { get; set; }
    }
}
