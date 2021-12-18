
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class QaCheckCategories
    {
        [JsonProperty("empty")]
        public bool? Empty { get; set; }

        [JsonProperty("size")]
        public bool? Size { get; set; }

        [JsonProperty("tags")]
        public bool? Tags { get; set; }
        
        [JsonProperty("spaces")]
        public bool? Spaces { get; set; }
        
        [JsonProperty("variables")]
        public bool? Variables { get; set; }
        
        [JsonProperty("punctuation")]
        public bool? Punctuation { get; set; }
        
        [JsonProperty("symbolRegister")]
        public bool? SymbolRegister { get; set; }
        
        [JsonProperty("specialSymbols")]
        public bool? SpecialSymbols { get; set; }
        
        [JsonProperty("wrongTranslation")]
        public bool? WrongTranslation { get; set; }
        
        [JsonProperty("spellcheck")]
        public bool? SpellCheck { get; set; }
        
        [JsonProperty("icu")]
        public bool? Icu { get; set; }
        
        [JsonProperty("terms")]
        public bool? Terms { get; set; }
        
        [JsonProperty("duplicate")]
        public bool? Duplicate { get; set; }
    }
}