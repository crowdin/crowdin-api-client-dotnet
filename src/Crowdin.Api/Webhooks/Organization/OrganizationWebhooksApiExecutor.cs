
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Abstractions;
using Crowdin.Api.Core;

namespace Crowdin.Api.Webhooks.Organization
{
    public class OrganizationWebhooksApiExecutor : IOrganizationWebhooksApiExecutor
    {
        private const string BaseUrl = "/webhooks";
        
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public OrganizationWebhooksApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public OrganizationWebhooksApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List webhook. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.webhooks.getMany">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.webhooks.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<OrganizationWebhookResource>> ListWebhooks(int limit = 25, int offset = 0)
        {
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            CrowdinApiResult result = await _apiClient.SendGetRequest(BaseUrl, queryParams);
            return _jsonParser.ParseResponseList<OrganizationWebhookResource>(result.JsonObject);
        }

        /// <summary>
        /// Add webhook. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.webhooks.post">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.webhooks.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<OrganizationWebhookResource> AddWebhook(AddWebhookRequestBase request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(BaseUrl, request);
            return _jsonParser.ParseResponseObject<OrganizationWebhookResource>(result.JsonObject);
        }

        /// <summary>
        /// Get webhook. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.webhooks.get">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.webhooks.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<OrganizationWebhookResource> GetWebhook(int organizationWebhookId)
        {
            string url = FormUrl_WebhookId(organizationWebhookId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<OrganizationWebhookResource>(result.JsonObject);
        }

        /// <summary>
        /// Delete webhook. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.webhooks.delete">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.webhooks.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteWebhook(int organizationWebhookId)
        {
            string url = FormUrl_WebhookId(organizationWebhookId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Webhook {organizationWebhookId} removal failed");
        }

        /// <summary>
        /// Edit webhook. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.webhooks.patch">Crowdin API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.webhooks.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<OrganizationWebhookResource> EditWebhook(
            int organizationWebhookId,
            IEnumerable<OrganizationWebhookPatch> patches)
        {
            string url = FormUrl_WebhookId(organizationWebhookId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<OrganizationWebhookResource>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_WebhookId(int organizationWebhookId)
        {
            return $"/webhooks/{organizationWebhookId}";
        }

        #endregion
    }
}