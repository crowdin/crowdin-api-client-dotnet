
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.StringTranslations
{
    [PublicAPI]
    public class WordAlignment
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("alignments")]
        public Alignment[] Alignments { get; set; }
    }
}