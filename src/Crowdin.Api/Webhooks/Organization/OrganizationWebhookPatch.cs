
using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Webhooks.Organization
{
    [PublicAPI]
    public class OrganizationWebhookPatch : PatchEntry
    {
        [JsonProperty("path")]
        public OrganizationWebhookPatchPath Path { get; set; }
    }

    [PublicAPI]
    public enum OrganizationWebhookPatchPath
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