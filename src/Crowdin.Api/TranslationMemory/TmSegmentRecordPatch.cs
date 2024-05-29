
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.TranslationMemory
{
    [PublicAPI]
    public class TmSegmentRecordPatch : PatchEntry
    {
        [JsonProperty("path")]
        public TmSegmentRecordPatchPath Path { get; set; }
    }
    
    [PublicAPI]
    public enum TmSegmentRecordPatchPath
    {
        [SerializedValue("/text")]
        Text
    }
}