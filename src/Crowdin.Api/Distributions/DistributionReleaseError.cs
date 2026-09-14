#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Distributions
{
    /// <summary>
    /// Describes why a distribution release failed.
    /// </summary>
    [PublicAPI]
    public class DistributionReleaseError
    {
        /// <summary>
        /// The error message returned by the Crowdin API.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; } = null!;
    }
}
