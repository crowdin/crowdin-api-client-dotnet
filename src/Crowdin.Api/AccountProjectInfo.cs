using System;
using Crowdin.Api.Json;
using Newtonsoft.Json;

namespace Crowdin.Api
{
    public sealed class AccountProjectInfo
    {
        [JsonProperty("role")]
        public String Role { get; private set; }

        [JsonProperty("name")]
        public String Name { get; private set; }

        [JsonProperty("identifier")]
        public String Identifier { get; private set; }

        [JsonProperty("downloadable")]
        [JsonConverter(typeof(BooleanConverter))]
        public Boolean Downloadable { get; private set; }

        [JsonProperty("key")]
        public String Key { get; private set; }

        public override String ToString() => Name;
    }
}
