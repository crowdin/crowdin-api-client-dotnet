#nullable enable

using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class ApplyApplicationInstallationUpdateRequest
    {
        [JsonProperty("manifestHash")]
        public string ManifestHash { get; set; } = null!;
    }
}
