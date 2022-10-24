
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class AddTermRequest
    {
        [JsonProperty("languageId")]
#pragma warning disable CS8618
        public string LanguageId { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("text")]
#pragma warning disable CS8618
        public string Text { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("partOfSpeech")]
        public PartOfSpeech? PartOfSpeech { get; set; }
        
        [JsonProperty("status")]
        public TermStatus? Status { get; set; }
        
        [JsonProperty("type")]
        public TermType? Type { get; set; }
        
        [JsonProperty("gender")]
        public TermGender? Gender { get; set; }
        
        [JsonProperty("note")]
        public string? Note { get; set; }
        
        [JsonProperty("url")]
        public string? Url { get; set; }
        
        [JsonProperty("conceptId")]
        public int? ConceptId { get; set; }
        
        [Obsolete]
        [JsonProperty("translationOfTermId")]
        public int? TranslationOfTermId { get; set; }
    }
}