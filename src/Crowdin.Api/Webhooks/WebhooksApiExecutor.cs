
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

namespace Crowdin.Api.Webhooks
{
    public class WebhooksApiExecutor : IWebhooksApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public WebhooksApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public WebhooksApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// List webhooks. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.webhooks.getMany">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.webhooks.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<Webhook>> ListWebhooks(long projectId, int limit = 25, int offset = 0)
        {
            string url = FormUrl_Webhooks(projectId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Webhook>(result.JsonObject);
        }

        /// <summary>
        /// Add webhook. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.webhooks.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.webhooks.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Webhook> AddWebhook(long projectId, AddWebhookRequest request)
        {
            string url = FormUrl_Webhooks(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Webhook>(result.JsonObject);
        }

        /// <summary>
        /// Get webhook. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.webhooks.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.webhooks.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Webhook> GetWebhook(long projectId, long webhookId)
        {
            string url = FormUrl_WebhookId(projectId, webhookId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Webhook>(result.JsonObject);
        }

        /// <summary>
        /// Delete webhook. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.webhooks.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.webhooks.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteWebhook(long projectId, long webhookId)
        {
            string url = FormUrl_WebhookId(projectId, webhookId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Webhook {webhookId} removal failed");
        }

        /// <summary>
        /// Edit webhook. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.projects.webhooks.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.projects.webhooks.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<Webhook> EditWebhook(long projectId, long webhookId, IEnumerable<WebhookPatch> patches)
        {
            string url = FormUrl_WebhookId(projectId, webhookId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Webhook>(result.JsonObject);
        }

        #region Helper methods

        private static string FormUrl_Webhooks(long projectId)
        {
            return $"/projects/{projectId}/webhooks";
        }

        private static string FormUrl_WebhookId(long projectId, long webhookId)
        {
            return $"/projects/{projectId}/webhooks/{webhookId}";
        }

        #endregion
    }
}