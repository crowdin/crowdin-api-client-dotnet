
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.AI.Gateway
{
    [PublicAPI]
    public class AiGatewayApiExecutor : IAiGatewayApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;
        
        public AiGatewayApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }
        
        public AiGatewayApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// AI Gateway GET. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.get">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.get">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.enterprise.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> ExecuteGet(long? userId, long aiProviderId, string path)
        {
            string url = FormUrl_AiGatewayRoute(userId, aiProviderId, path);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return result.JsonObject;
        }

        /// <summary>
        /// AI Gateway POST. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.post">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.post">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.enterprise.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> ExecutePost(long? userId, long aiProviderId, string path, object request)
        {
            string url = FormUrl_AiGatewayRoute(userId, aiProviderId, path);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return result.JsonObject;
        }

        /// <summary>
        /// AI Gateway PUT. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.put">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.put">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.enterprise.put">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> ExecutePut(long? userId, long aiProviderId, string path, object request)
        {
            string url = FormUrl_AiGatewayRoute(userId, aiProviderId, path);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url, request);
            return result.JsonObject;
        }

        /// <summary>
        /// AI Gateway DELETE. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.delete">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.delete">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.enterprise.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> ExecuteDelete(long? userId, long aiProviderId, string path)
        {
            string url = FormUrl_AiGatewayRoute(userId, aiProviderId, path);
            CrowdinApiResult result = await _apiClient.SendDeleteRequest_FullResult(url);
            return result.JsonObject;
        }

        /// <summary>
        /// AI Gateway PATCH. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.patch">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI-Gateway/operation/api.ai.providers.gateway.crowdin.patch">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI-Gateway/operation/api.ai.providers.gateway.enterprise.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> ExecutePatch(long? userId, long aiProviderId, string path, object request)
        {
            string url = FormUrl_AiGatewayRoute(userId, aiProviderId, path);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, request);
            return result.JsonObject;
        }

        #region Helper methods

        private static string FormUrl_AiGatewayRoute(long? userId, long aiProviderId, string path)
        {
            return AddUserIdIfAvailable(userId, $"/ai/providers/{aiProviderId}/gateway/{path}");
        }

        private static string AddUserIdIfAvailable(long? userId, string baseUrl)
        {
            return userId.HasValue ? $"/users/{userId}" + baseUrl : baseUrl;
        }

        #endregion
    }
}