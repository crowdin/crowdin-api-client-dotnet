#nullable enable

using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Placeholders
{
    [PublicAPI]
    public class CustomPlaceholderPatch : PatchEntry
    {
        [JsonProperty("path")]
        public CustomPlaceholderPatchPath Path { get; set; }
    }
}
