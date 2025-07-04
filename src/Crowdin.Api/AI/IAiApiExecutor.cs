
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace Crowdin.Api.AI
{
    [PublicAPI]
    public interface IAiApiExecutor
    {
        #region Prompt Fine-Tuning Datasets

        Task<AiFineTuningDataset> GenerateAiPromptFineTuningDataset(
            long? userId,
            long aiPromptId,
            GenerateAiPromptFineTuningDatasetRequest request);

        Task<AiFineTuningDataset> GetAiPromptFineTuningDatasetGenerationStatus(
            long? userId,
            long aiPromptId,
            string jobIdentifier);

        Task<AiFineTuningJob> CreateAiPromptFineTuningJob(
            long? userId,
            long aiPromptId,
            CreateAiPromptFineTuningJobRequest request);

        Task<AiFineTuningJob> GetAiPromptFineTuningJobStatus(
            long? userId,
            long aiPromptId,
            string jobIdentifier);

        Task<DownloadLink> DownloadAiPromptFineTuningDataset(
            long? userId,
            long aiPromptId,
            string jobIdentifier);

        #endregion

        #region Prompts

        Task<AiPromptResource> CloneAiPrompt(long? userId, long aiPromptId, CloneAiPromptRequest request);

        Task<ResponseList<AiPromptResource>> ListAiPrompts(
            long? userId,
            long? projectId = null,
            AiPromptAction? action = null,
            int limit = 25, int offset = 0);

        Task<AiPromptResource> AddAiPrompt(long? userId, AddAiPromptRequest request);

        Task<AiPromptCompletion> GenerateAiPromptCompletion(
            long? userId,
            long aiPromptId,
            GenerateAiPromptCompletionRequest request);

        Task<AiPromptCompletion> GetAiPromptCompletionStatus(
            long? userId,
            long aiPromptId,
            string completionId);

        Task CancelAiPromptCompletion(long? userId, long aiPromptId, string completionId);

        Task<DownloadLink> DownloadAiPromptCompletion(long? userId, long aiPromptId, string completionId);

        Task<AiPromptResource> GetAiPrompt(long? userId, long aiPromptId);

        Task DeleteAiPrompt(long? userId, long aiPromptId);

        Task<AiPromptResource> EditAiPrompt(
            long? userId, long aiPromptId,
            IEnumerable<AiPromptPatch> patches);

        #endregion

        #region Providers

        Task<ResponseList<AiProviderResource>> ListAiProviders(long? userId, int limit = 25, int offset = 0);

        Task<AiProviderResource> AddAiProvider(long? userId, AddAiProviderRequest request);

        Task<AiProviderResource> GetAiProvider(long? userId, long aiProviderId);

        Task DeleteAiProvider(long? userId, long aiProviderId);

        Task<AiProviderResource> EditAiProvider(long? userId, long aiProviderId, IEnumerable<AiProviderPatch> patches);

        Task<ResponseList<AiProviderModelResource>> ListAiProviderModels(long? userId, long aiProviderId);
        
        #endregion

        #region Reports

        Task<AiReportGenerationStatus> GenerateAiReport(long? userId, GenerateAiReport request);

        Task<AiReportGenerationStatus> CheckAiReportGenerationStatus(long? userId, string aiReportId);

        Task<DownloadLink> DownloadAiReport(long? userId, string aiReportId);
        
        #endregion

        #region Settings

        Task<AiSettings> GetAiSettings(long? userId);

        Task<AiSettings> EditAiSettings(long? userId, IEnumerable<AiSettingsPatch> patches);
        
        #endregion
        
        Task<AiProxyChatCompletion> CreateAiProxyChatCompletion(
            long? userId,
            long aiProviderId,
            IDictionary<string, object> request);
    }
}