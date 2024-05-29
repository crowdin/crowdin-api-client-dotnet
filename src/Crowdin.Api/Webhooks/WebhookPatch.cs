
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Webhooks
{
    [PublicAPI]
    public class WebhookPatch : PatchEntry
    {
        [JsonProperty("path")]
        public WebhookPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum WebhookPatchPath
    {
        [SerializedValue("/name")]
        Name,
        
        [SerializedValue("/url")]
        Url,
        
        [SerializedValue("/isActive")]
        IsActive,
        
        [SerializedValue("/batchingEnabled")]
        BatchingEnabled,
        
        [SerializedValue("/contentType")]
        ContentType,
        
        [SerializedValue("/events")]
        Events,
        
        [SerializedValue("/headers")]
        Headers,
        
        [SerializedValue("/requestType")]
        RequestType,
        
        [SerializedValue("/payload")]
        Payload
    }
}