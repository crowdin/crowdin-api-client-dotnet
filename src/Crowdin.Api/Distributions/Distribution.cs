﻿
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public class Distribution
    {
        [JsonProperty("hash")]
#pragma warning disable CS8618
        public string Hash { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("exportMode")]
        public DistributionExportMode ExportMode { get; set; }
        
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("fileIds")]
#pragma warning disable CS8618
        public int[] FileIds { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("bundleIds")]
#pragma warning disable CS8618
        public int[] BundleIds { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}