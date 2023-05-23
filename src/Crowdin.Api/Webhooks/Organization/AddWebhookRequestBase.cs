
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crowdin.Api.Webhooks.Organization
{
    public abstract class AddWebhookRequestBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("requestType")]
        public RequestType RequestType { get; set; }
        
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }
        
        [JsonProperty("batchingEnabled")]
        public bool? BatchingEnabled { get; set; }
        
        [JsonProperty("contentType")]
        public ContentType? ContentType { get; set; }
        
#nullable enable
        [JsonProperty("headers")]
        public IDictionary<string, string>? Headers { get; set; }
        
        [JsonProperty("payload")]
        public object? Payload { get; set; }
#nullable disable
    }
}