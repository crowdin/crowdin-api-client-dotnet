
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Glossaries
{
    [PublicAPI]
    public class TermPatch : PatchEntry
    {
        [JsonProperty("path")]
        public TermPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum TermPatchPath
    {
        [Description("/text")]
        Text,
        
        [Description("/description")]
        Description,
        
        [Description("/partOfSpeech")]
        PartOfSpeech
    }
}