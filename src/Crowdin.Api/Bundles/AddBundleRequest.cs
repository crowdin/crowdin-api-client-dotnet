
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Bundles
{
    [PublicAPI]
    public class AddBundleRequest
    {
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("format")]
#pragma warning disable CS8618
        public string Format { get; set; }
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
        
        [JsonProperty("isMultilingual")]
        public bool? IsMultilingual { get; set; }
        
        [JsonProperty("includeProjectSourceLanguage")]
        public bool? IncludeProjectSourceLanguage { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<int>? LabelIds { get; set; }
    }
}