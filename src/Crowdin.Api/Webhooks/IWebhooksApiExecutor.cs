
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks
{
    [PublicAPI]
    public interface IWebhooksApiExecutor
    {
        Task<ResponseList<Webhook>> ListWebhooks(int projectId, int limit = 25, int offset = 0);

        Task<Webhook> AddWebhook(int projectId, AddWebhookRequest request);

        Task<Webhook> GetWebhook(int projectId, int webhookId);

        Task DeleteWebhook(int projectId, int webhookId);

        Task<Webhook> EditWebhook(int projectId, int webhookId, IEnumerable<WebhookPatch> patches);
    }
}