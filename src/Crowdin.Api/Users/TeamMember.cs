
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Users
{
    [PublicAPI]
    public class TeamMember
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        
        [JsonProperty("role")]
        public UserRole Role { get; set; }
        
        [JsonProperty("permissions")]
        public IDictionary<string, string> Permissions { get; set; }
        
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }
        
        [JsonProperty("joinedAt")]
        public DateTimeOffset JoinedAt { get; set; }
        
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
    }
}