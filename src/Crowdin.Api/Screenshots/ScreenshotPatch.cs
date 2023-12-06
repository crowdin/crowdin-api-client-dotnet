
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Screenshots
{
    [PublicAPI]
    public class ScreenshotPatch : PatchEntry
    {
        [JsonProperty("path")]
        public ScreenshotPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum ScreenshotPatchPath
    {
        [Description("/name")]
        Name,

        [Description("/labelIds")]
        LabelIds
    }
}