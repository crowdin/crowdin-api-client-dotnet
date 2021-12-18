
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.SourceFiles
{
    [PublicAPI]
    public class AddDirectoryRequest
    {
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("branchId")]
        public int? BranchId { get; set; }
        
        [JsonProperty("directoryId")]
        public int? DirectoryId { get; set; }
        
        [JsonProperty("title")]
        public string? Title { get; set; }
        
        [JsonProperty("exportPattern")]
        public string? ExportPattern { get; set; }
        
        [JsonProperty("priority")]
        public Priority? Priority { get; set; }
    }
}