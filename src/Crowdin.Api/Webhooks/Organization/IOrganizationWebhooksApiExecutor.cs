
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

        Task<OrganizationWebhookResource> GetWebhook(int organizationWebhookId);

        Task DeleteWebhook(int organizationWebhookId);

        Task<OrganizationWebhookResource> EditWebhook(
            int organizationWebhookId,
            IEnumerable<OrganizationWebhookPatch> patches);
    }
}