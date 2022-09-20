
using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Webhooks
{
    [PublicAPI]
    public class Webhook
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("events")]
        public EventType[] Events { get; set; }
        
        [JsonProperty("headers")]
        public IDictionary<string, string> Headers { get; set; }
        
        [JsonProperty("payload")]
        public IDictionary<string, IDictionary<string, string>> Payload { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("batchingEnabled")]
        public bool BatchingEnabled { get; set; }
        
        [JsonProperty("requestType")]
        public RequestType RequestType { get; set; }
        
        [JsonProperty("contentType")]
        public ContentType ContentType { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}