
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Applications
{
    [PublicAPI]
    public class ApplicationConsentUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; } = null!;

        [JsonProperty("fullName")]
        public string FullName { get; set; } = null!;

        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; } = null!;
    }
}
