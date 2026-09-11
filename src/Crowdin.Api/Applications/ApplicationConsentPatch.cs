
using System.ComponentModel;

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class ApplicationConsentPatch : PatchEntry
    {
        [JsonProperty("path")]
        public ApplicationConsentPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum ApplicationConsentPatchPath
    {
        [Description("/status")]
        Status,

        [Description("/scopes")]
        Scopes
    }
}
