
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class AddApplicationConsentRequest
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; } = null!;

        [JsonProperty("installedBy")]
        public long InstalledBy { get; set; }

        [JsonProperty("status")]
        public ApplicationConsentStatus Status { get; set; }

        [JsonProperty("scopes")]
        public ICollection<string>? Scopes { get; set; }
    }
}
