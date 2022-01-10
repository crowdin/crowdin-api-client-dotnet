
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class ExportGlossaryRequest
    {
        [JsonProperty("format")]
        public GlossaryFormat Format { get; set; }
    }
}