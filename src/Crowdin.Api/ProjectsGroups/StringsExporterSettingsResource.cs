using System;
using Crowdin.Api.SourceFiles;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class StringsExporterSettingsResource
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("format")]
        public ProjectFileType Format { get; set; }

        [JsonProperty("settings")]
        public StringsExporterSettings Settings { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}