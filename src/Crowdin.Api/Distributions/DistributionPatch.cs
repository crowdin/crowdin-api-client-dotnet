
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
    }

    [PublicAPI]
    public enum DistributionPatchPath
    {
        [SerializedValue("/exportMode")]
        ExportMode,
        
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/fileIds")]
        FileIds,
        
        [SerializedValue("/bundleIds")]
        BundleIds,
    }
}