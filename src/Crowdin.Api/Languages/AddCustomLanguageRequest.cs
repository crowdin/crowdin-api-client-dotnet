
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Languages
{
    [PublicAPI]
    public class AddCustomLanguageRequest
    {
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("code")]
#pragma warning disable CS8618
        public string Code { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("localeCode")]
#pragma warning disable CS8618
        public string LocaleCode { get; set; }
#pragma warning restore CS8618
            
        [JsonProperty("textDirection")]
        public TextDirection TextDirection { get; set; }
        
        [JsonProperty("pluralCategoryNames")]
#pragma warning disable CS8618
        public ICollection<string> PluralCategoryNames { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("threeLettersCode")]
#pragma warning disable CS8618
        public string ThreeLettersCode { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("twoLettersCode")]
        public string? TwoLettersCode { get; set; }
        
        [JsonProperty("dialectOf")]
        public string? DialectOf { get; set; }
    }
}