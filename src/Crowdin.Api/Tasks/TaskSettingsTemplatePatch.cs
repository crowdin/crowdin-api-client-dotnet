
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Tasks
{
    [PublicAPI]
    public class TaskSettingsTemplatePatch : PatchEntry
    {
        [JsonProperty("path")]
        public TaskSettingsTemplatePatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum TaskSettingsTemplatePatchPath
    {
        [Description("/name")]
        Name,
        
        [Description("/config")]
        Config
    }
}