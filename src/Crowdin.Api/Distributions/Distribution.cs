
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public class Distribution
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }
        
        [JsonProperty("manifestUrl")]
        public string ManifestUrl { get; set; }
        
        [JsonProperty("exportMode")]
        public DistributionExportMode ExportMode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fileIds")]
        public long[] FileIds { get; set; }

        [JsonProperty("bundleIds")]
        public long[] BundleIds { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}