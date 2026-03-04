
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core;

#nullable enable

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public class AddDistributionRequest
    {
        [JsonProperty("exportMode")]
        [Obsolete(MessageTexts.DeprecatedProperty)]
        public DistributionExportMode? ExportMode { get; set; }
        
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("fileIds")]
        [Obsolete(MessageTexts.DeprecatedProperty)]
#pragma warning disable CS8618
        public ICollection<long>? FileIds { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("bundleIds")]
#pragma warning disable CS8618
        public ICollection<long>? BundleIds { get; set; }
#pragma warning restore CS8618
    }
}