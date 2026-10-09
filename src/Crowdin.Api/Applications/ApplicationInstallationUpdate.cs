#nullable enable

using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class ApplicationInstallationUpdate
    {
        [JsonProperty("manifestHash")]
        public string? ManifestHash { get; set; }

        [JsonProperty("latestManifest")]
        public JObject? LatestManifest { get; set; }

        [JsonProperty("addedScopes")]
        public string[] AddedScopes { get; set; } = null!;

        [JsonProperty("removedScopes")]
        public string[] RemovedScopes { get; set; } = null!;

        [JsonProperty("addedModules")]
        public JObject[] AddedModules { get; set; } = null!;

        [JsonProperty("removedModules")]
        public JObject[] RemovedModules { get; set; } = null!;

        [JsonProperty("changedModules")]
        public JObject[] ChangedModules { get; set; } = null!;

        [JsonProperty("changedEvents")]
        public IDictionary<string, ApplicationInstallationUpdateChange> ChangedEvents { get; set; } = null!;

        [JsonProperty("baseUrlChanged")]
        public ApplicationInstallationUpdateChange? BaseUrlChanged { get; set; }

        [JsonProperty("authenticationTypeChanged")]
        public ApplicationInstallationUpdateChange? AuthenticationTypeChanged { get; set; }

        [JsonProperty("hasChanges")]
        public bool HasChanges { get; set; }
    }
}
