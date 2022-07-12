
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
        [Description("/exportMode")]
        ExportMode,
        
        [Description("/name")]
        Name,
        
        [Description("/fileIds")]
        FileIds,
        
        [Description("/format")]
        Format,
        
        [Description("/exportPattern")]
        ExportPattern,
        
        [Description("/labelIds")]
        LabelIds
    }
}