
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class ProjectFileFormatSettingsPatch : PatchEntry
    {
        [JsonProperty("path")]
        public ProjectFileFormatSettingsPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum ProjectFileFormatSettingsPatchPath
    {
        [Description("/format")]
        Format,
        
        [Description("/settings")]
        Settings
    }
}