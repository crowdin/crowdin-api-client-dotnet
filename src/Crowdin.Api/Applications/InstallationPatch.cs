using JetBrains.Annotations;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class InstallationPatch: PatchEntry
    {
        [JsonProperty("path")]
        public InstallationPatchPath Path {  get; set; }
    }

    [PublicAPI]
    public enum InstallationPatchPath
    {
        [SerializedValue("/permissions")]
        Permissions
    }
}