
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class VendorTaskPatch : TaskPatchBase
    {
        [JsonProperty("path")]
        public VendorTaskPatchPath Path { get; set; }
    }
    
    [PublicAPI]
    public enum VendorTaskPatchPath
    {
        [Description("/title")]
        Title,
        
        [Description("/description")]
        Description,
        
        [Description("/status")]
        Status
    }
}