
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Branches
{
    [PublicAPI]
    public class BranchPatch : PatchEntry
    {
        [JsonProperty("path")]
        public BranchPatchPath Path { get; set; }
    }
    
    [PublicAPI]
    public enum BranchPatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/title")]
        Title,
        
        [Description("/priority")]
        Priority
    }
}