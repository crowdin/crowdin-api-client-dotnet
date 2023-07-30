
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Notifications
{
    [PublicAPI]
    public class SendNotificationToAuthenticatedUserRequest
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}