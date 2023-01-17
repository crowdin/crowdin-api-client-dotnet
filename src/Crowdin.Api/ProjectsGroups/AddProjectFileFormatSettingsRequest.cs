
using Crowdin.Api.SourceFiles;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class AddProjectFileFormatSettingsRequest
    {
        [JsonProperty("format")]
        public ProjectFileType Format { get; set; }
        
        [JsonProperty("settings")]
        public FileFormatSettings Settings { get; set; }
    }
}