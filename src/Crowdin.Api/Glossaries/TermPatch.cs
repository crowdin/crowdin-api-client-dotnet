
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
        [SerializedValue("/text")]
        Text,
        
        [SerializedValue("/description")]
        Description,
        
        [SerializedValue("/partOfSpeech")]
        PartOfSpeech,
        
        [SerializedValue("/status")]
        Status,
        
        [SerializedValue("/type")]
        Type,
        
        [SerializedValue("/gender")]
        Gender,
        
        [SerializedValue("/url")]
        Url,
        
        [SerializedValue("/note")]
        Note
    }
}