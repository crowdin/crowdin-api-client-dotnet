
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.Core;

namespace Crowdin.Api.AI
{
    public class AiApiExecutor : IAiApiExecutor
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

        #region Prompt Fine-Tuning Datasets

        /// <summary>
        /// Generate AI Prompt Fine-Tuning Dataset. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI/operation/api.ai.prompts.fine-tuning.datasets.post">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI/operation/api.ai.prompts.fine-tuning.datasets.post">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI/operation/api.ai.prompts.fine-tuning.datasets.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiFineTuningDataset> GenerateAiPromptFineTuningDataset(
            long? userId,
            long aiPromptId,
            GenerateAiPromptFineTuningDatasetRequest request)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/prompts/{aiPromptId}/fine-tuning/datasets");
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<AiFineTuningDataset>(result.JsonObject);
        }

        /// <summary>
        /// Get AI Prompt Fine-Tuning Dataset Generation Status. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI/operation/api.users.ai.prompts.fine-tuning.datasets.get">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI/operation/api.users.ai.prompts.fine-tuning.datasets.get">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI/operation/api.ai.prompts.fine-tuning.datasets.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiFineTuningDataset> GetAiPromptFineTuningDatasetGenerationStatus(
            long? userId,
            long aiPromptId,
            string jobIdentifier)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/prompts/{aiPromptId}/fine-tuning/datasets/{jobIdentifier}");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<AiFineTuningDataset>(result.JsonObject);
        }

        /// <summary>
        /// Create AI Prompt Fine-Tuning Job. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI/operation/api.ai.prompts.fine-tuning.jobs.post">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI/operation/api.ai.prompts.fine-tuning.jobs.post">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI/operation/api.ai.prompts.fine-tuning.jobs.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiFineTuningJob> CreateAiPromptFineTuningJob(
            long? userId,
            long aiPromptId,
            CreateAiPromptFineTuningJobRequest request)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/prompts/{aiPromptId}/fine-tuning/jobs");
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<AiFineTuningJob>(result.JsonObject);
        }

        /// <summary>
        /// Get AI Prompt Fine-Tuning Job Status. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI/operation/api.users.ai.prompts.fine-tuning.jobs.get">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI/operation/api.users.ai.prompts.fine-tuning.jobs.get">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI/operation/api.ai.prompts.fine-tuning.jobs.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiFineTuningJob> GetAiPromptFineTuningJobStatus(
            long? userId,
            long aiPromptId,
            string jobIdentifier)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/prompts/{aiPromptId}/fine-tuning/jobs/{jobIdentifier}");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<AiFineTuningJob>(result.JsonObject);
        }
        
        /// <summary>
        /// Download AI Prompt Fine-Tuning Dataset. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/AI/operation/api.users.ai.prompts.fine-tuning.datasets.download.get">Crowdin File Based API</a>
        /// <a href="https://support.crowdin.com/developer/api/v2/string-based/#tag/AI/operation/api.users.ai.prompts.fine-tuning.datasets.download.get">Crowdin String Based API</a>
        /// <a href="https://support.crowdin.com/developer/enterprise/api/v2/#tag/AI/operation/api.ai.prompts.fine-tuning.datasets.download.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadAiPromptFineTuningDataset(
            long? userId,
            long aiPromptId,
            string jobIdentifier)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/prompts/{aiPromptId}/fine-tuning/datasets/{jobIdentifier}/download");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        #endregion
        
        #region Prompts

        /// <summary>
        /// Clone AI Prompt. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#tag/AI/operation/api.users.ai.prompts.clones.post">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#tag/AI/operation/api.users.ai.prompts.clones.post">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#tag/AI/operation/api.ai.prompts.clones.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiPromptResource> CloneAiPrompt(long? userId, long aiPromptId, CloneAiPromptRequest request)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/prompts/{aiPromptId}/clones");
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<AiPromptResource>(result.JsonObject);
        }
        
        /// <summary>
        /// List AI Prompts. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.ai.prompts.getMany">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.ai.prompts.getMany">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.prompts.getMany">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<ResponseList<AiPromptResource>> ListAiPrompts(
            long? userId,
            long? projectId = null,
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
        public async Task<AiPromptResource> AddAiPrompt(long? userId, AddAiPromptRequest request)
        {
            string url = FormUrl_AiPrompts(userId);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<AiPromptResource>(result.JsonObject);
        }

        /// <summary>
        /// Generate AI Prompt Completion. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#tag/AI/operation/api.ai.prompts.completions.post">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#tag/AI/operation/api.ai.prompts.completions.post">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#tag/AI/operation/api.ai.prompts.completions.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiPromptCompletion> GenerateAiPromptCompletion(
            long? userId,
            long aiPromptId,
            GenerateAiPromptCompletionRequest request)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/prompts/{aiPromptId}/completions");
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<AiPromptCompletion>(result.JsonObject);
        }

        /// <summary>
        /// Get AI Prompt Completion Status. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#tag/AI/operation/api.users.ai.prompts.completions.get">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#tag/AI/operation/api.users.ai.prompts.completions.get">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#tag/AI/operation/api.ai.prompts.completions.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiPromptCompletion> GetAiPromptCompletionStatus(
            long? userId,
            long aiPromptId,
            string completionId)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/prompts/{aiPromptId}/completions/{completionId}");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<AiPromptCompletion>(result.JsonObject);
        }

        /// <summary>
        /// Cancel AI Prompt Completion. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#tag/AI/operation/api.users.ai.prompts.completions.delete">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#tag/AI/operation/api.users.ai.prompts.completions.delete">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#tag/AI/operation/api.ai.prompts.completions.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task CancelAiPromptCompletion(long? userId, long aiPromptId, string completionId)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/prompts/{aiPromptId}/completions/{completionId}");
            HttpStatusCode statusCode = await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"AI prompt completion {completionId} cancellation failed");
        }

        /// <summary>
        /// Download AI Prompt Completion. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#tag/AI/operation/api.users.ai.prompts.completions.download.download">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#tag/AI/operation/api.users.ai.prompts.completions.download.download">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#tag/AI/operation/api.ai.prompts.completions.download.download">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadAiPromptCompletion(long? userId, long aiPromptId, string completionId)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/prompts/{aiPromptId}/completions/{completionId}/download");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }
        
        /// <summary>
        /// Get AI Prompt. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.ai.prompts.get">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.users.ai.prompts.get">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.prompts.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiPromptResource> GetAiPrompt(long? userId, long aiPromptId)
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
        public async Task DeleteAiPrompt(long? userId, long aiPromptId)
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
            long? userId, long aiPromptId,
            IEnumerable<AiPromptPatch> patches)
        {
            string url = FormUrl_AiPromptId(userId, aiPromptId);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<AiPromptResource>(result.JsonObject);
        }
        
        #region Helper methods
        
        private static string FormUrl_AiPrompts(long? userId)
        {
            return AddUserIdIfAvailable(userId, "/ai/prompts");
        }
        
        private static string FormUrl_AiPromptId(long? userId, long aiPromptId)
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
        public async Task<ResponseList<AiProviderResource>> ListAiProviders(long? userId, int limit = 25, int offset = 0)
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
        public async Task<AiProviderResource> AddAiProvider(long? userId, AddAiProviderRequest request)
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
        public async Task<AiProviderResource> GetAiProvider(long? userId, long aiProviderId)
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
        public async Task DeleteAiProvider(long? userId, long aiProviderId)
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
        public async Task<AiProviderResource> EditAiProvider(long? userId, long aiProviderId, IEnumerable<AiProviderPatch> patches)
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
        public async Task<ResponseList<AiProviderModelResource>> ListAiProviderModels(long? userId, long aiProviderId)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/providers/{aiProviderId}/models");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseList<AiProviderModelResource>(result.JsonObject);
        }
        
        #region Helper methods
        
        private static string FormUrl_AiProviders(long? userId)
        {
            return AddUserIdIfAvailable(userId, "/ai/providers");
        }
        
        private static string FormUrl_AiProviderId(long? userId, long aiProviderId)
        {
            return AddUserIdIfAvailable(userId, $"/ai/providers/{aiProviderId}");
        }
        
        #endregion
        
        #endregion

        #region Reports

        /// <summary>
        /// Generate AI Report. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#tag/AI/operation/api.users.ai.reports.post">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#tag/AI/operation/api.users.ai.reports.post">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#tag/AI/operation/api.ai.reports.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiReportGenerationStatus> GenerateAiReport(long? userId, GenerateAiReport request)
        {
            string url = AddUserIdIfAvailable(userId, "/ai/reports");
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<AiReportGenerationStatus>(result.JsonObject);
        }

        /// <summary>
        /// Check AI Report Generation Status. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#tag/AI/operation/api.users.ai.reports.get">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#tag/AI/operation/api.users.ai.reports.get">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#tag/AI/operation/api.ai.reports.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiReportGenerationStatus> CheckAiReportGenerationStatus(long? userId, string aiReportId)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/reports/{aiReportId}");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<AiReportGenerationStatus>(result.JsonObject);
        }

        /// <summary>
        /// Download AI Report. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#tag/AI/operation/api.users.ai.reports.download.download">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#tag/AI/operation/api.users.ai.reports.download.download">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#tag/AI/operation/api.ai.reports.download.download">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<DownloadLink> DownloadAiReport(long? userId, string aiReportId)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/reports/{aiReportId}/download");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<DownloadLink>(result.JsonObject);
        }

        #endregion

        #region Settings

        /// <summary>
        /// Get AI Settings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#tag/AI/operation/api.users.ai.settings.get">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#tag/AI/operation/api.users.ai.settings.get">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#tag/AI/operation/api.ai.settings.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiSettings> GetAiSettings(long? userId)
        {
            string url = AddUserIdIfAvailable(userId, "/ai/settings");
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return _jsonParser.ParseResponseObject<AiSettings>(result.JsonObject);
        }

        /// <summary>
        /// Edit AI Settings. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#tag/AI/operation/api.users.ai.settings.patch">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#tag/AI/operation/api.users.ai.settings.patch">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#tag/AI/operation/api.ai.settings.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiSettings> EditAiSettings(long? userId, IEnumerable<AiSettingsPatch> patches)
        {
            string url = AddUserIdIfAvailable(userId, "/ai/settings");
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return _jsonParser.ParseResponseObject<AiSettings>(result.JsonObject);
        }

        #endregion
        
        /// <summary>
        /// Create AI Proxy Chat Completion. Documentation:
        /// <a href="https://developer.crowdin.com/api/v2/#operation/api.users.ai.providers.chat.completions.post">Crowdin File Based API</a>
        /// <a href="https://developer.crowdin.com/api/v2/string-based/#operation/api.users.ai.providers.chat.completions.post">Crowdin String Based API</a>
        /// <a href="https://developer.crowdin.com/enterprise/api/v2/#operation/api.ai.providers.chat.completions.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<AiProxyChatCompletion> CreateAiProxyChatCompletion(
            long? userId,
            long aiProviderId,
            IDictionary<string, object> request)
        {
            string url = AddUserIdIfAvailable(userId, $"/ai/providers/{aiProviderId}/chat/completions");
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return _jsonParser.ParseResponseObject<AiProxyChatCompletion>(result.JsonObject);
        }
        
        #region Helper methods
        
        private static string AddUserIdIfAvailable(long? userId, string baseUrl)
        {
            return userId.HasValue ? $"/users/{userId}" + baseUrl : baseUrl;
        }
        
        #endregion
    }
}