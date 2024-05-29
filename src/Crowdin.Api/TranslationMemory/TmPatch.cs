
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
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/groupId")]
        GroupId,
        
        [SerializedValue("/languageId")]
        LanguageId
    }
}