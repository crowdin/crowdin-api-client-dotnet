
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks
{
    [PublicAPI]
    public interface IWebhooksApiExecutor
    {
        Task<ResponseList<Webhook>> ListWebhooks(long projectId, int limit = 25, int offset = 0);

        Task<Webhook> AddWebhook(long projectId, AddWebhookRequest request);

        Task<Webhook> GetWebhook(long projectId, long webhookId);

        Task DeleteWebhook(long projectId, long webhookId);

        Task<Webhook> EditWebhook(long projectId, long webhookId, IEnumerable<WebhookPatch> patches);
    }
}