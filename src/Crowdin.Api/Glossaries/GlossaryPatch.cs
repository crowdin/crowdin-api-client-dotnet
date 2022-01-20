
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class GlossaryPatch : PatchEntry
    {
        [JsonProperty("path")]
        public GlossaryPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum GlossaryPatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/languageId")]
        LanguageId
    }
}