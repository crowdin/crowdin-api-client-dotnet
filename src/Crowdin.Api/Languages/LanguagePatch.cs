
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Languages
{
    [PublicAPI]
    public class LanguagePatch : PatchEntry
    {
        [JsonProperty("path")]
        public LanguagePatchPath Path { get; set; }
    }
}