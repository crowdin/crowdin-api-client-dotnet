
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TmConcordanceResultResource
    {
        [JsonProperty("tm")]
        public TranslationMemory Tm { get; set; }
        
        [JsonProperty("recordId")]
        public int RecordId { get; set; }
        
        [JsonProperty("source")]
        public string Source { get; set; }
        
        [JsonProperty("target")]
        public string Target { get; set; }
        
        [JsonProperty("relevant")]
        public int Relevant { get; set; }
        
        [JsonProperty("substituted")]
        public string Substituted { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}