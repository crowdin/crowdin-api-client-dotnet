
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.Webhooks
{
    public class WebhooksApiExecutor
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

        [PublicAPI]
        public async Task<ResponseList<Webhook>> ListWebhooks(int projectId, int limit = 25, int offset = 0)
        {
            string url = FormUrl_Webhooks(projectId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);

            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<Webhook>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Webhook> AddWebhook(int projectId, AddWebhookRequest request)
        {
            string url = FormUrl_Webhooks(projectId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<Webhook>(result.JsonObject);
        }

        [PublicAPI]
        public async Task<Webhook> GetWebhook(int projectId, int webhookId)
        {
            string url = FormUrl_WebhookId(projectId, webhookId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<Webhook>(result.JsonObject);
        }

        [PublicAPI]
        public async Task DeleteWebhook(int projectId, int webhookId)
        {
            string url = FormUrl_WebhookId(projectId, webhookId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Webhook {webhookId} removal failed");
        }

        [PublicAPI]
        public async Task<Webhook> EditWebhook(int projectId, int webhookId, IEnumerable<WebhookPatch> patches)
        {
            string url = FormUrl_WebhookId(projectId, webhookId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<Webhook>(result.JsonObject);
        }

        #region MyRegion

        private static string FormUrl_Webhooks(int projectId)
        {
            return $"/projects/{projectId}/webhooks";
        }

        private static string FormUrl_WebhookId(int projectId, int webhookId)
        {
            return $"/projects/{projectId}/webhooks/{webhookId}";
        }

        #endregion
    }
}