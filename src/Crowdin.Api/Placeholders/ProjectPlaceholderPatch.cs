#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public class ProjectPlaceholderPatch : PatchEntry
    {
        [JsonProperty("path")]
        public ProjectPlaceholderPatchPath Path { get; set; }
    }
}
