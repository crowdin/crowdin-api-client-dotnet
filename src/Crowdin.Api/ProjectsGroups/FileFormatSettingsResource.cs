
using System;
using Crowdin.Api.SourceFiles;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.ProjectsGroups
{
    [PublicAPI]
    public class FileFormatSettingsResource
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("format")]
        public ProjectFileType Format { get; set; }
        
        [JsonProperty("extensions")]
        public string[] Extensions { get; set; }
        
        [JsonProperty("settings")]
        public FileFormatSettings Settings { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}