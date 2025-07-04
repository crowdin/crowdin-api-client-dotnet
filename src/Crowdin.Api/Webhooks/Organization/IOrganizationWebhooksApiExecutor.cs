
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks.Organization
{
    [PublicAPI]
    public interface IOrganizationWebhooksApiExecutor
    {
        Task<ResponseList<OrganizationWebhookResource>> ListWebhooks(int limit = 25, int offset = 0);

        Task<OrganizationWebhookResource> AddWebhook(AddWebhookRequestBase request);

        Task<OrganizationWebhookResource> GetWebhook(long organizationWebhookId);

        Task DeleteWebhook(long organizationWebhookId);

        Task<OrganizationWebhookResource> EditWebhook(
            long organizationWebhookId,
            IEnumerable<OrganizationWebhookPatch> patches);
    }
}