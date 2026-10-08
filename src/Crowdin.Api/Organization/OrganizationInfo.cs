#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Organization
{
    [PublicAPI]
    public class OrganizationInfo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; } = null!;

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("logo")]
        public string? Logo { get; set; }

        [JsonProperty("defaultLogo")]
        public string DefaultLogo { get; set; } = null!;

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("internalDescription")]
        public string? InternalDescription { get; set; }

        [JsonProperty("cname")]
        public string? Cname { get; set; }

        [JsonProperty("isVendor")]
        public bool IsVendor { get; set; }

        [JsonProperty("defaultPublicProjectsView")]
        public OrganizationProjectsView DefaultPublicProjectsView { get; set; }

        [JsonProperty("plan")]
        public OrganizationPlan Plan { get; set; } = null!;

        [JsonProperty("defaults")]
        public OrganizationDefault[] Defaults { get; set; } = null!;
    }
}
