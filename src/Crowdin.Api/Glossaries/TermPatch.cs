
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
        PartOfSpeech,
        
        [Description("/status")]
        Status,
        
        [Description("/type")]
        Type,
        
        [Description("/gender")]
        Gender,
        
        [Description("/url")]
        Url,
        
        [Description("/note")]
        Note
    }
}