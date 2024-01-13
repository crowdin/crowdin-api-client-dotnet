using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class ApplicationPermissions
    {
        [JsonProperty("user")]
        public ApplicationUser User { get; set; }

        [JsonProperty("project")]
        public ApplicationProject Project { get; set; }

    }
}
