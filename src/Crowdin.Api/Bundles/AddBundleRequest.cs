
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Bundles
{
    [PublicAPI]
    public class AddBundleRequest
    {
        [JsonProperty("applicationId")]
#pragma warning disable CS8618
        public string ApplicationId { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("sourcePatterns")]
#pragma warning disable CS8618
        public ICollection<string> SourcePatterns { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("ignorePatterns")]
        public ICollection<string>? IgnorePatterns { get; set; }
        
        [JsonProperty("exportPattern")]
#pragma warning disable CS8618
        public string ExportPattern { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("labelIds")]
        public ICollection<int>? LabelIds { get; set; }
    }
}