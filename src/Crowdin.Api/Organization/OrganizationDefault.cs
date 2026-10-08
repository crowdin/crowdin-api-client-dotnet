#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Organization
{
    [PublicAPI]
    public class OrganizationDefault
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("isLocked")]
        public bool IsLocked { get; set; }

        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; } = null!;
    }
}
