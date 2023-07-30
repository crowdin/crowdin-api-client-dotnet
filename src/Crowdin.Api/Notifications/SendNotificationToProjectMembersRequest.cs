
using System.Collections.Generic;
using Crowdin.Api.Users;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Notifications
{
    [PublicAPI]
    public class SendNotificationToProjectMembersRequest
    {
        [JsonProperty("userIds")]
        public ICollection<int> UserIds { get; set; }
        
        [JsonProperty("role")]
        public UserRole? Role { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}