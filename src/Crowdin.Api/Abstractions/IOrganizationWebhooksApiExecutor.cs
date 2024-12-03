
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Webhooks.Organization;

namespace Crowdin.Api.Abstractions
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