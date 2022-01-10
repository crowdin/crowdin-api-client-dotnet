
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public class AddDistributionRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("fileIds")]
        public ICollection<int> FileIds { get; set; }
    }
}