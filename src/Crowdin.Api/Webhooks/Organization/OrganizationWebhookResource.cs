
using System;
using System.Collections.Generic;

using JetBrains.Annotations;
using Newtonsoft.Json;

using Crowdin.Api.Core.Converters;

namespace Crowdin.Api.Webhooks.Organization
{
    [PublicAPI]
    public class OrganizationWebhookResource
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("events")]
        public OrganizationEventType[] Events { get; set; }
        
        [JsonProperty("headers")]
        [JsonConverter(typeof(EmptyArrayAsObjectConverter))]
        public IDictionary<string, string> Headers { get; set; }
        
        [JsonProperty("payload")]
        public object Payload { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("batchingEnabled")]
        public bool BatchingEnabled { get; set; }
        
        [JsonProperty("requestType")]
        public RequestType RequestType { get; set; }
        
        [JsonProperty("contentType")]
        public ContentType? ContentType { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}