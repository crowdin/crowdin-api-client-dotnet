
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Translations
{
    [PublicAPI]
    public class PreTranslationPatch : PatchEntry
    {
        [JsonProperty("path")]
        public PreTranslationPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum PreTranslationPatchPath
    {
        [Description("/status")]
        Status
    }
}