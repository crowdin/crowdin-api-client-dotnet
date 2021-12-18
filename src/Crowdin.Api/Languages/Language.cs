
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Languages
{
    [PublicAPI]
    public class Language
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("editorCode")]
        public string EditorCode { get; set; }
        
        [JsonProperty("twoLettersCode")]
        public string TwoLettersCode { get; set; }
        
        [JsonProperty("threeLettersCode")]
        public string ThreeLettersCode { get; set; }
        
        [JsonProperty("locale")]
        public string Locale { get; set; }
        
        [JsonProperty("androidCode")]
        public string AndroidCode { get; set; }
        
        [JsonProperty("osxCode")]
        public string OsxCode { get; set; }
        
        [JsonProperty("osxLocale")]
        public string OsxLocale { get; set; }
        
        [JsonProperty("pluralCategoryNames")]
        public string[] PluralCategoryNames { get; set; }
        
        [JsonProperty("pluralRules")]
        public string PluralRules { get; set; }
        
        [JsonProperty("pluralExamples")]
        public string[] PluralExamples { get; set; }
        
        [JsonProperty("textDirection")]
        public TextDirection TextDirection { get; set; }
        
        [JsonProperty("dialectOf")]
        public string DialectOf { get; set; }
    }
}