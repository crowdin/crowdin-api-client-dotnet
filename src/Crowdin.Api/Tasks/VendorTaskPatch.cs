
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
        [SerializedValue("/title")]
        Title,
        
        [SerializedValue("/description")]
        Description,
        
        [SerializedValue("/status")]
        Status
    }
}