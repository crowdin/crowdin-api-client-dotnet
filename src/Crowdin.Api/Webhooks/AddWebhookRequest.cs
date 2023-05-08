
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

#nullable enable

namespace Crowdin.Api.Webhooks
{
    [PublicAPI]
    public class AddWebhookRequest
    {
        [JsonProperty("name")]
#pragma warning disable CS8618
        public string Name { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("url")]
#pragma warning disable CS8618
        public string Url { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("events")]
#pragma warning disable CS8618
        public ICollection<EventType> Events { get; set; }
#pragma warning restore CS8618
        
        [JsonProperty("requestType")]
        public RequestType RequestType { get; set; }
        
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }
        
        [JsonProperty("batchingEnabled")]
        public bool? BatchingEnabled { get; set; }
        
        [JsonProperty("contentType")]
        public ContentType? ContentType { get; set; }
        
        [JsonProperty("headers")]
        public IDictionary<string, string>? Headers { get; set; }
        
        [JsonProperty("payload")]
        public object? Payload { get; set; }
    }
}