
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Issues
{
    [PublicAPI]
    public class IssuePatch : PatchEntry
    {
        [JsonProperty("path")]
        public IssuePatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum IssuePatchPath
    {
        [Description("/status")]
        Status
    }
}