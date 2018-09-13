using System;
using Newtonsoft.Json;

namespace Crowdin.Api
{
    public sealed class LanguageInfo
    {
        [JsonProperty("name")]
        public String Name { get; private set; }

        [JsonProperty("crowdin_code")]
        public String CrowdinCode { get; private set; }

        [JsonProperty("editor_code")]
        public String EditorCode { get; private set; }

        [JsonProperty("iso_639_1")]
        public String Iso6391 { get; private set; }

        [JsonProperty("iso_639_3")]
        public String Iso6393 { get; private set; }

        [JsonProperty("locale")]
        public String Locale { get; private set; }

        [JsonProperty("android_code")]
        public String AndroidCode { get; private set; }

        [JsonProperty("osx_code")]
        public String OsXCode { get; private set; }

        [JsonProperty("osx_locale")]
        public String OsXLocale { get; private set; }

        public override String ToString()
        {
            return Name;
        }
    }
}
