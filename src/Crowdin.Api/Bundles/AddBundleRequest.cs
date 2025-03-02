
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
        public string Name { get; set; } = null!;

        [JsonProperty("format")]
        public string Format { get; set; } = null!;

        [JsonProperty("sourcePatterns")]
        public ICollection<string> SourcePatterns { get; set; } = null!;
        
        [JsonProperty("ignorePatterns")]
        public ICollection<string>? IgnorePatterns { get; set; }

        [JsonProperty("exportPattern")]
        public string ExportPattern { get; set; } = null!;
        
        [JsonProperty("isMultilingual")]
        public bool? IsMultilingual { get; set; }
        
        [JsonProperty("includeProjectSourceLanguage")]
        public bool? IncludeProjectSourceLanguage { get; set; }
        
        [JsonProperty("includeInContextPseudoLanguage")]
        public bool? IncludeInContextPseudoLanguage { get; set; }
        
        [JsonProperty("labelIds")]
        public ICollection<int>? LabelIds { get; set; }
        
        [JsonProperty("excludeLabelIds")]
        public ICollection<int>? ExcludeLabelIds { get; set; }
    }
}