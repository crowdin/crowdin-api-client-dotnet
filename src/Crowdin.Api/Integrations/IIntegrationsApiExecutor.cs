#nullable enable

using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Integrations
{
    [PublicAPI]
    public interface IIntegrationsApiExecutor
    {
        Task<IList<IntegrationJob>> ListJobs(
            string applicationIdentifier,
            long projectId,
            int? limit = null,
            int? offset = null);

        Task<IList<IntegrationJob>> GetJobInfo(string applicationIdentifier, long projectId, string jobId);

        Task<IList<IntegrationJob>> GetJobs(
            string applicationIdentifier,
            long projectId,
            string? jobId = null);

        Task CancelJob(string applicationIdentifier, long projectId, string jobId);

        Task<IList<JObject>> ListIntegrationCrowdinFiles(string applicationIdentifier, long projectId);

        Task<IntegrationJob> UpdateIntegrationCrowdinFiles(
            string applicationIdentifier,
            UpdateCrowdinFilesRequest request);

        Task<IntegrationFileProgress> GetIntegrationFileProgress(
            string applicationIdentifier,
            long projectId,
            long fileId);

        Task<IList<JObject>> ListIntegrationFiles(string applicationIdentifier, long projectId);

        Task<IntegrationJob> UpdateIntegrationFiles(
            string applicationIdentifier,
            UpdateIntegrationFilesRequest request);

        Task<JObject?> IntegrationLogin(string applicationIdentifier, IntegrationLoginRequest request);

        Task<IList<IntegrationLoginField>> ListIntegrationLoginFields(string applicationIdentifier);

        Task<JObject> GetApplicationSettings(string applicationIdentifier, long projectId);

        Task UpdateApplicationSettings(
            string applicationIdentifier,
            UpdateApplicationSettingsRequest request);

        Task<JToken> GetSyncSettings(string applicationIdentifier, long projectId, string provider);

        Task UpdateSyncSettings(string applicationIdentifier, UpdateApplicationSyncSettingsRequest request);
    }
}
