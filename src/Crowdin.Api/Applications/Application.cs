#nullable enable annotations

using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class Application
    {
        private Application() { }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }

        [JsonProperty("manifestUrl")]
        public string ManifestUrl { get; set; }

        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }

        [JsonProperty("modules")]
        public ApplicationModule[] Modules { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("permissions")]
        public ApplicationPermissions Permissions { get; set; }

        [JsonProperty("defaultPermissions")]
        public JObject DefaultPermissions { get; set; }

        [JsonProperty("limitReached")]
        public bool LimitReached { get; set; }

        [JsonProperty("installedBy")]
        public JObject? InstalledBy { get; set; }

        [JsonProperty("logoUrl")]
        public string? LogoUrl { get; set; }

        [JsonProperty("agent")]
        public JObject? Agent { get; set; }

        [JsonProperty("manifest")]
        public JObject? Manifest { get; set; }

        [JsonProperty("manifestUpdatedAt")]
        public DateTimeOffset? ManifestUpdatedAt { get; set; }

        [JsonProperty("isManifestOutdated")]
        public bool? IsManifestOutdated { get; set; }

        [JsonProperty("stringBasedAvailable")]
        public bool? StringBasedAvailable { get; set; }

        [JsonProperty("bundle")]
        public JToken? Bundle { get; set; }
    }
}
