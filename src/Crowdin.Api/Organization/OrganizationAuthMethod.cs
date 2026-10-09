#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Organization
{
    [PublicAPI]
    public class OrganizationAuthMethod
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }
    }
}
