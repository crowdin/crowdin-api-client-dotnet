
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class Concept
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("userId")]
        public int UserId { get; set; }
        
        [JsonProperty("glossaryId")]
        public int GlossaryId { get; set; }
        
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
        public ConceptLanguageDetails[] LanguagesDetails { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}