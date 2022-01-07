
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
        [Description("/name")]
        Name,
        
        [Description("/url")]
        Url,
        
        [Description("/isActive")]
        IsActive,
        
        [Description("/batchingEnabled")]
        BatchingEnabled,
        
        [Description("/contentType")]
        ContentType,
        
        [Description("/events")]
        Events,
        
        [Description("/headers")]
        Headers,
        
        [Description("/requestType")]
        RequestType,
        
        [Description("/payload")]
        Payload
    }
}