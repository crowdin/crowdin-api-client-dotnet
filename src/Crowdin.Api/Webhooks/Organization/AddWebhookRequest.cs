
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Webhooks.Organization
{
    [PublicAPI]
    public class AddWebhookRequest : AddWebhookRequestBase
    {
        [JsonProperty("events")]
        public ICollection<OrganizationEventType> Events { get; set; }
    }
}