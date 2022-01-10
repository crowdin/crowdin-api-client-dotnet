
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class User : UserBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("lastSeen")]
        public DateTimeOffset? LastSeen { get; set; }
        
        [JsonProperty("twoFactor")]
        public UserTwoFactorStatus TwoFactor { get; set; }
        
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
    }
}