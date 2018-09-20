using System;
using Newtonsoft.Json;

namespace Crowdin.Api
{
    public class Language
    {
        [JsonProperty("name")]
        public String Name { get; private set; }

        [JsonProperty("code")]
        public String CrowdinCode { get; private set; }

        public override String ToString() => Name;
    }
}
