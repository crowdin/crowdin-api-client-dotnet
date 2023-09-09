using Crowdin.Api.SourceFiles;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class AddProjectStringsExporterSettingsRequest
    {
        [JsonProperty("format")]
        public ProjectFileType Format { get; set; }

        [JsonProperty("settings")]
        public StringsExporterSettings Settings { get; set; }
    }
}