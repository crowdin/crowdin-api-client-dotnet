
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public class DistributionPatch : PatchEntry
    {
        [JsonProperty("path")]
        public DistributionPatchPath Path { get; set; }
        
        [JsonProperty("value")]
        public new string Value { get; set; }
    }

    [PublicAPI]
    public enum DistributionPatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/title")]
        Title,
        
        [Description("/exportPattern")]
        ExportPattern,
        
        [Description("/priority")]
        Priority
    }
}