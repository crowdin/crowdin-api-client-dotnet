using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class ProjectStringsExporterSettingsPatch : PatchEntry
    {
        [JsonProperty("path")]
        public ProjectStringsExporterSettingsPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum ProjectStringsExporterSettingsPatchPath
    {
        [SerializedValue("/format")]
        Format,
        
        [SerializedValue("/settings")]
        Settings
    }
}