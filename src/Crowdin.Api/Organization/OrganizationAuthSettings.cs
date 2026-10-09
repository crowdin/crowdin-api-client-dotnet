#nullable enable

using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Organization
{
    [PublicAPI]
    public class OrganizationAuthSettings
    {
        [JsonProperty("allowSignUp")]
        public bool AllowSignUp { get; set; }

        [JsonProperty("twoFactorAuthentication")]
        public bool TwoFactorAuthentication { get; set; }

        [JsonProperty("authMethods")]
        public OrganizationAuthMethod[] AuthMethods { get; set; } = null!;
    }
}
