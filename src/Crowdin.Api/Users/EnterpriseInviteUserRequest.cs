
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class EnterpriseInviteUserRequest
    {
        [JsonProperty("email")]
#pragma warning disable CS8618
        public string Email { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string? LastName { get; set; }
        
        [JsonProperty("timezone")]
        public string? TimeZone { get; set; }

        [JsonProperty("adminAccess")]
        public bool? AdminAccess { get; set; }
    }
}