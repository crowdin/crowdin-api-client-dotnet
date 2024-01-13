using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class InstallApplicationRequest
    {
        [JsonProperty("url")]
#pragma warning disable CS8618 
        public string Url { get; set; }
#pragma warning restore CS8618 
        
        [JsonProperty("permissions")]
        public ApplicationPermissions? Permissions { get; set; }
    }
}
