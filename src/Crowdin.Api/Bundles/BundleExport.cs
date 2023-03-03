
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Bundles
{
    [PublicAPI]
    public class BundleExport
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        
        [JsonProperty("status")]
        public BuildStatus Status { get; set; }
        
        [JsonProperty("progress")]
        public int Progress { get; set; }
        
        [JsonProperty("attributes")]
        public BundleExportAttributes Attributes { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
        
        [JsonProperty("startedAt")]
        public DateTimeOffset? StartedAt { get; set; }
        
        [JsonProperty("finishedAt")]
        public DateTimeOffset? FinishedAt { get; set; }
    }
}