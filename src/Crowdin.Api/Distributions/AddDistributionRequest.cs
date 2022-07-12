
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public class AddDistributionRequest
    {
        [JsonProperty("exportMode")]
        public DistributionExportMode? ExportMode { get; set; }
        
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("fileIds")]
#pragma warning disable CS8618
        public ICollection<int> FileIds { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("format")]
        public string? Format { get; set; }
        
        [JsonProperty("exportPattern")]
        public string? ExportPattern { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<int>? LabelIds { get; set; }
    }
}