#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Distributions
{
    [PublicAPI]
    public class DistributionReleaseError
    {
        [JsonProperty("message")]
        public string Message { get; set; } = null!;
    }
}
