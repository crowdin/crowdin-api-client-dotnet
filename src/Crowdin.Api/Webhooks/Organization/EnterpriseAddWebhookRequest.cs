
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Crowdin.Api.Webhooks.Organization
{
    [PublicAPI]
    public class EnterpriseAddWebhookRequest : AddWebhookRequestBase
    {
        [JsonProperty("events")]
        public ICollection<EnterpriseOrgEventType> Events { get; set; }
    }
}