
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Branches
{
    [PublicAPI]
    public class AddBranchRequest
    {
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("title")]
        public string? Title { get; set; }
    }
}