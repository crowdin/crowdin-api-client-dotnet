
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TmPatch : PatchEntry
    {
        [JsonProperty("path")]
        public TmPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum TmPatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/groupId")]
        GroupId,
        
        [Description("/languageId")]
        LanguageId
    }
}