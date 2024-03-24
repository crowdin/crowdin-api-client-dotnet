
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.SecurityLogs
{
    [PublicAPI]
    public class SecurityLog
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("event")]
        public SecurityLogEventType Event { get; set; }
        
        [JsonProperty("info")]
        public string Info { get; set; }
        
        [JsonProperty("userId")]
        public long UserId { get; set; }
        
        [JsonProperty("location")]
        public string Location { get; set; }
        
        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; }
        
        [JsonProperty("deviceName")]
        public string DeviceName { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}