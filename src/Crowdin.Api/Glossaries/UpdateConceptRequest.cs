
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class UpdateConceptRequest
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }
        
        [JsonProperty("definition")]
        public string Definition { get; set; }
        
        [JsonProperty("note")]
        public string Note { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("figure")]
        public string Figure { get; set; }
        
        [JsonProperty("languagesDetails")]
        public ICollection<ConceptLanguageDetailsForm> LanguagesDetails { get; set; }
    }
}