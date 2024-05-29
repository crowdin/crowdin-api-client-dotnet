
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class EnterpriseUserPatch : PatchEntry
    {
        [JsonProperty("path")]
        public EnterpriseUserPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum EnterpriseUserPatchPath
    {
        [SerializedValue("/firstName")]
        FirstName,
        
        [SerializedValue("/lastName")]
        LastName,
        
        [SerializedValue("/timezone")]
        TimeZone,
        
        [SerializedValue("/status")]
        Status
    }
}