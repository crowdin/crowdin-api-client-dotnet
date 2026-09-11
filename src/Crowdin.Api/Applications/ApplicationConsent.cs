
using System;

using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class ApplicationConsent
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("installedBy")]
        public ApplicationConsentUser? InstalledBy { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; } = null!;

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("status")]
        public ApplicationConsentStatus Status { get; set; }

        [JsonProperty("scopes")]
        public string[] Scopes { get; set; } = null!;

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
