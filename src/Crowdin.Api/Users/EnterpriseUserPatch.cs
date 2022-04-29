
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
        [Description("/firstName")]
        FirstName,
        
        [Description("/lastName")]
        LastName,
        
        [Description("/timezone")]
        TimeZone,
        
        [Description("/status")]
        Status
    }
}