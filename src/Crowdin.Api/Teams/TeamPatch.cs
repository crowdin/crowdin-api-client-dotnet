
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Teams
{
    [PublicAPI]
    public class TeamPatch : PatchEntry
    {
        [JsonProperty("path")]
        public TeamPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum TeamPatchPath
    {
        [SerializedValue("/name")]
        Name
    }
}