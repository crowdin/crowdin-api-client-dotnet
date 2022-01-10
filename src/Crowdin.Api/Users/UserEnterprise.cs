
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class UserEnterprise : UserBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("status")]
        public UserStatus Status { get; set; }
        
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("lastSeen")]
        public DateTimeOffset? LastSeen { get; set; }
        
        [JsonProperty("twoFactor")]
        public UserTwoFactorStatus TwoFactor { get; set; }
        
        [JsonProperty("isAdmin")]
        public bool IsAdmin { get; set; }
        
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
    }
}