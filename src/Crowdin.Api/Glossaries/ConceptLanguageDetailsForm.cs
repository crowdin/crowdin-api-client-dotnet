
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class ConceptLanguageDetailsForm
    {
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("definition")]
        public string Definition { get; set; }
        
        [JsonProperty("note")]
        public string Note { get; set; }
    }
}