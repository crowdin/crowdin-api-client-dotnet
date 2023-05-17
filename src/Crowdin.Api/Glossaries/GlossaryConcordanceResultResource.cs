
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class GlossaryConcordanceResultResource
    {
        [JsonProperty("glossary")]
        public Glossary Glossary { get; set; }
        
        [JsonProperty("concept")]
        public Concept Concept { get; set; }
        
        [JsonProperty("sourceTerms")]
        public Term[] SourceTerms { get; set; }
        
        [JsonProperty("targetTerms")]
        public Term[] TargetTerms { get; set; }
    }
}