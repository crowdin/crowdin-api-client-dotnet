
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