#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class ApplicationInstallationUpdateChange
    {
        [JsonProperty("from")]
        public string? From { get; set; }

        [JsonProperty("to")]
        public string? To { get; set; }
    }
}
