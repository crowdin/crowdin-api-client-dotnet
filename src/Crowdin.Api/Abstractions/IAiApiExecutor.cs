
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Crowdin.Api.AI;

namespace Crowdin.Api.Abstractions
{
    [PublicAPI]
    public interface IAiApiExecutor
    {
        #region Prompt Fine-Tuning Datasets

        Task<AiFineTuningDataset> GenerateAiPromptFineTuningDataset(
            int? userId,
            int aiPromptId,
            GenerateAiPromptFineTuningDatasetRequest request);

        Task<AiFineTuningDataset> GetAiPromptFineTuningDatasetGenerationStatus(
            int? userId,
            int aiPromptId,
            string jobIdentifier);

        Task<AiFineTuningJob> CreateAiPromptFineTuningJob(
            int? userId,
            int aiPromptId,
            CreateAiPromptFineTuningJobRequest request);

        Task<AiFineTuningJob> GetAiPromptFineTuningJobStatus(
            int? userId,
            int aiPromptId,
            string jobIdentifier);

        Task<DownloadLink> DownloadAiPromptFineTuningDataset(
            int? userId,
            int aiPromptId,
            string jobIdentifier);

        #endregion

        #region Prompts

        Task<AiPromptResource> CloneAiPrompt(int? userId, int aiPromptId, CloneAiPromptRequest request);

        Task<ResponseList<AiPromptResource>> ListAiPrompts(
            int? userId,
            int? projectId = null,
            AiPromptAction? action = null,
            int limit = 25, int offset = 0);

        Task<AiPromptResource> AddAiPrompt(int? userId, AddAiPromptRequest request);

        Task<AiPromptCompletion> GenerateAiPromptCompletion(
            int? userId,
            int aiPromptId,
            GenerateAiPromptCompletionRequest request);

        Task<AiPromptCompletion> GetAiPromptCompletionStatus(
            int? userId,
            int aiPromptId,
            string completionId);

        Task CancelAiPromptCompletion(int? userId, int aiPromptId, string completionId);

        Task<DownloadLink> DownloadAiPromptCompletion(int? userId, int aiPromptId, string completionId);

        Task<AiPromptResource> GetAiPrompt(int? userId, int aiPromptId);

        Task DeleteAiPrompt(int? userId, int aiPromptId);

        Task<AiPromptResource> EditAiPrompt(
            int? userId, int aiPromptId,
            IEnumerable<AiPromptPatch> patches);

        #endregion

        #region Providers

        Task<ResponseList<AiProviderResource>> ListAiProviders(int? userId, int limit = 25, int offset = 0);

        Task<AiProviderResource> AddAiProvider(int? userId, AddAiProviderRequest request);

        Task<AiProviderResource> GetAiProvider(int? userId, int aiProviderId);

        Task DeleteAiProvider(int? userId, int aiProviderId);

        Task<AiProviderResource> EditAiProvider(int? userId, int aiProviderId, IEnumerable<AiProviderPatch> patches);

        Task<ResponseList<AiProviderModelResource>> ListAiProviderModels(int? userId, int aiProviderId);
        
        #endregion

        #region Reports

        Task<AiReportGenerationStatus> GenerateAiReport(int? userId, GenerateAiReport request);

        Task<AiReportGenerationStatus> CheckAiReportGenerationStatus(int? userId, string aiReportId);

        Task<DownloadLink> DownloadAiReport(int? userId, string aiReportId);
        
        #endregion

        #region Settings

        Task<AiSettings> GetAiSettings(int? userId);

        Task<AiSettings> EditAiSettings(int? userId, IEnumerable<AiSettingsPatch> patches);
        
        #endregion
        
        Task<AiProxyChatCompletion> CreateAiProxyChatCompletion(
            int? userId,
            int aiProviderId,
            IDictionary<string, object> request);
    }
}