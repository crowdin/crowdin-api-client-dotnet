
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;
using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    public class AiApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;
        
        public AiApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }
        
        public AiApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }
        
        #region Prompts
        
        /// <summary>
        /// List AI Prompts. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.ai.prompts.getMany">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.ai.prompts.getMany">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.prompts.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<AiPromptResource>> ListAiPrompts(
            int? userId,
            int? projectId = null,
            AiPromptAction? action = null,
            int limit = 25, int offset = 0)
        {
            string url = FormUrl_AiPrompts(userId);
            
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            queryParams.AddParamIfPresent("projectId", projectId);
            queryParams.AddDescriptionEnumValueIfPresent("action", action);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<AiPromptResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Add AI Prompt. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.ai.prompts.post">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.users.ai.prompts.post">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.prompts.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiPromptResource> AddAiPrompt(int? userId, AddAiPromptRequest request)
        {
            string url = FormUrl_AiPrompts(userId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<AiPromptResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Get AI Prompt. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.ai.prompts.get">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.users.ai.prompts.get">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.prompts.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiPromptResource> GetAiPrompt(int? userId, int aiPromptId)
        {
            string url = FormUrl_AiPromptId(userId, aiPromptId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<AiPromptResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Delete AI Prompt. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.ai.prompts.delete">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.users.ai.prompts.delete">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.prompts.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteAiPrompt(int? userId, int aiPromptId)
        {
            string url = FormUrl_AiPromptId(userId, aiPromptId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"AI Prompt {aiPromptId} removal failed");
        }
        
        /// <summary>
        /// Edit AI Prompt. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.ai.prompts.patch">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.users.ai.prompts.patch">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.prompts.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiPromptResource> EditAiPrompt(
            int? userId, int aiPromptId,
            IEnumerable<AiPromptPatch> patches)
        {
            string url = FormUrl_AiPromptId(userId, aiPromptId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<AiPromptResource>(result.JsonObject);
        }
        
        #region Helper methods
        
        private static string FormUrl_AiPrompts(int? userId)
        {
            return AddUserIdIfAvailable(userId, "/ai/prompts");
        }
        
        private static string FormUrl_AiPromptId(int? userId, int aiPromptId)
        {
            return AddUserIdIfAvailable(userId, $"/ai/prompts/{aiPromptId}");
        }
        
        #endregion
        
        #endregion
        
        #region Providers
        
        /// <summary>
        /// List AI Providers. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.ai.providers.getMany">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.ai.providers.getMany">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.providers.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<AiProviderResource>> ListAiProviders(int? userId, int limit = 25, int offset = 0)
        {
            string url = FormUrl_AiProviders(userId);
            IDictionary<string, string> queryParams = Utils.CreateQueryParamsFromPaging(limit, offset);
            
            CrowdinApiResult result = await _apiClient.SendGetRequest(url, queryParams);
            return _jsonParser.ParseResponseList<AiProviderResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Add AI Provider. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.ai.providers.post">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.users.ai.providers.post">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.providers.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiProviderResource> AddAiProvider(int? userId, AddAiProviderRequest request)
        {
            string url = FormUrl_AiProviders(userId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<AiProviderResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Get AI Provider. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.ai.providers.get">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.users.ai.providers.get">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.providers.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiProviderResource> GetAiProvider(int? userId, int aiProviderId)
        {
            string url = FormUrl_AiProviderId(userId, aiProviderId);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<AiProviderResource>(result.JsonObject);
        }
        
        /// <summary>
        /// Delete AI Provider. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.ai.providers.delete">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.users.ai.providers.delete">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.providers.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteAiProvider(int? userId, int aiProviderId)
        {
            string url = FormUrl_AiProviderId(userId, aiProviderId);
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"AI Provider {aiProviderId} removal failed");
        }
        
        /// <summary>
        /// Edit AI Provider. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.ai.providers.patch">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.users.ai.providers.patch">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.providers.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiProviderResource> EditAiProvider(int? userId, int aiProviderId, IEnumerable<AiProviderPatch> patches)
        {
            string url = FormUrl_AiProviderId(userId, aiProviderId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<AiProviderResource>(result.JsonObject);
        }
        
        /// <summary>
        /// List AI Provider Models. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.ai.providers.models.getMany">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.ai.providers.models.getMany">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.providers.models.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<AiProviderModelResource>> ListAiProviderModels(int? userId, int aiProviderId)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/providers/{aiProviderId}/models");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseList<AiProviderModelResource>(result.JsonObject);
        }
        
        #region Helper methods
        
        private static string FormUrl_AiProviders(int? userId)
        {
            return AddUserIdIfAvailable(userId, "/ai/providers");
        }
        
        private static string FormUrl_AiProviderId(int? userId, int aiProviderId)
        {
            return AddUserIdIfAvailable(userId, $"/ai/providers/{aiProviderId}");
        }
        
        #endregion
        
        #endregion
        
        /// <summary>
        /// Create AI Proxy Chat Completion. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.ai.providers.chat.completions.post">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.users.ai.providers.chat.completions.post">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.providers.chat.completions.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiProxyChatCompletion> CreateAiProxyChatCompletion(
            int? userId,
            int aiProviderId,
            IDictionary<string, object> request)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/providers/{aiProviderId}/chat/completions");
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<AiProxyChatCompletion>(result.JsonObject);
        }
        
        #region Helper methods
        
        private static string AddUserIdIfAvailable(int? userId, string baseUrl)
        {
            return userId.HasValue ? $"/users/{userId}" + baseUrl : baseUrl;
        }
        
        #endregion
    }
}