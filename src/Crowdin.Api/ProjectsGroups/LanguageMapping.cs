
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class LanguageMapping
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
        
        [JsonProperty("two_letters_code")]
        public string? TwoLettersCode { get; set; }
        
        [JsonProperty("three_letters_code")]
        public string? ThreeLettersCode { get; set; }
        
        [JsonProperty("locale")]
        public string? Locale { get; set; }
        
        [JsonProperty("locale_with_underscore")]
        public string? LocaleWithUnderscore { get; set; }
        
        [JsonProperty("android_code")]
        public string? AndroidCode { get; set; }
        
        [JsonProperty("osx_code")]
        public string? OsxCode { get; set; }
        
        [JsonProperty("osx_locale")]
        public string? OsxLocale { get; set; }
    }
}