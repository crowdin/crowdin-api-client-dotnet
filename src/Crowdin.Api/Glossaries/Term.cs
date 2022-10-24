
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class Term
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("userId")]
        public int UserId { get; set; }
        
        [JsonProperty("glossaryId")]
        public int GlossaryId { get; set; }
        
        [JsonProperty("languageId")]
        public string LanguageId { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("partOfSpeech")]
        public PartOfSpeech PartOfSpeech { get; set; }
        
        [JsonProperty("status")]
        public TermStatus Status { get; set; }
        
        [JsonProperty("type")]
        public TermType Type { get; set; }
        
        [JsonProperty("gender")]
        public TermGender Gender { get; set; }
        
        [JsonProperty("note")]
        public string Note { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("conceptId")]
        public int? ConceptId { get; set; }
        
        [JsonProperty("lemma")]
        public string Lemma { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}