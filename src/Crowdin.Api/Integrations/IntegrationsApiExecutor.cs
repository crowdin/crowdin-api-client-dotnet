#nullable enable

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Crowdin.Api.Core;

using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Integrations
{
    public class IntegrationsApiExecutor : IIntegrationsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public IntegrationsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public IntegrationsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        private static string Url(string id, string path) => $"/applications/{id}/api/{path}";

        /// <summary>
        /// List integration jobs. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.job.list">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<IList<IntegrationJob>> ListJobs(string applicationIdentifier, long projectId, int? limit = null, int? offset = null)
        {
            var @params = new IntegrationJobsListParams
            {
                ProjectId = projectId,
                Limit = limit,
                Offset = offset
            };
            CrowdinApiResult result = await _apiClient.SendGetRequest(Url(applicationIdentifier, "all-jobs"), @params.ToQueryParams());
            return _jsonParser.ParseArray<IntegrationJob>(result.JsonObject["data"]!);
        }

        /// <summary>
        /// Get integration job information. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.job.info">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<IList<IntegrationJob>> GetJobInfo(string applicationIdentifier, long projectId, string jobId)
        {
            var @params = new IntegrationJobsListParams { ProjectId = projectId, JobId = jobId };
            CrowdinApiResult result = await _apiClient.SendGetRequest(Url(applicationIdentifier, "job-info"), @params.ToQueryParams());
            return _jsonParser.ParseArray<IntegrationJob>(result.JsonObject["data"]!);
        }

        /// <summary>
        /// Get integration jobs. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.job.get">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<IList<IntegrationJob>> GetJobs(string applicationIdentifier, long projectId, string? jobId = null)
        {
            var @params = new IntegrationJobsListParams { ProjectId = projectId, JobId = jobId };
            CrowdinApiResult result = await _apiClient.SendGetRequest(Url(applicationIdentifier, "jobs"), @params.ToQueryParams());
            return _jsonParser.ParseArray<IntegrationJob>(result.JsonObject["data"]!);
        }

        /// <summary>
        /// Cancel an integration job. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.job.cancel">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task CancelJob(string applicationIdentifier, long projectId, string jobId)
        {
            var @params = new IntegrationJobsListParams { ProjectId = projectId, JobId = jobId };
            HttpStatusCode code = await _apiClient.SendDeleteRequest(Url(applicationIdentifier, "jobs"), @params.ToQueryParams());
            Utils.ThrowIfStatusNot204(code, $"Integration job {jobId} cancellation failed");
        }

        /// <summary>
        /// List Crowdin files for an integration. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.crowdin.files">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<IList<JObject>> ListIntegrationCrowdinFiles(string applicationIdentifier, long projectId)
        {
            var @params = new IntegrationFilesListParams { ProjectId = projectId };
            CrowdinApiResult result = await _apiClient.SendGetRequest(Url(applicationIdentifier, "crowdin-files"), @params.ToQueryParams());
            return _jsonParser.ParseArray<JObject>(result.JsonObject["data"]!);
        }

        /// <summary>
        /// Update Crowdin files for an integration. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.crowdin.update">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<IntegrationJob> UpdateIntegrationCrowdinFiles(string applicationIdentifier, UpdateCrowdinFilesRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(Url(applicationIdentifier, "crowdin-update"), request);
            return _jsonParser.ParseResponseObject<IntegrationJob>(result.JsonObject);
        }

        /// <summary>
        /// Get integration file progress. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.file.progress">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<IntegrationFileProgress> GetIntegrationFileProgress(string applicationIdentifier, long projectId, long fileId)
        {
            var @params = new IntegrationFilesListParams { ProjectId = projectId, FileId = fileId };
            CrowdinApiResult result = await _apiClient.SendGetRequest(Url(applicationIdentifier, "file-progress"), @params.ToQueryParams());
            return _jsonParser.ParseResponseObject<IntegrationFileProgress>(result.JsonObject);
        }

        /// <summary>
        /// List integration files. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.integration.files">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<IList<JObject>> ListIntegrationFiles(string applicationIdentifier, long projectId)
        {
            var @params = new IntegrationFilesListParams { ProjectId = projectId };
            CrowdinApiResult result = await _apiClient.SendGetRequest(Url(applicationIdentifier, "integration-files"), @params.ToQueryParams());
            return _jsonParser.ParseArray<JObject>(result.JsonObject["data"]!);
        }

        /// <summary>
        /// Update files in an integration. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.integration.update">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<IntegrationJob> UpdateIntegrationFiles(string applicationIdentifier, UpdateIntegrationFilesRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(Url(applicationIdentifier, "integration-update"), request);
            return _jsonParser.ParseResponseObject<IntegrationJob>(result.JsonObject);
        }

        /// <summary>
        /// Log in to an integration. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.integration.login">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject?> IntegrationLogin(string applicationIdentifier, IntegrationLoginRequest request)
        {
            CrowdinApiResult result = await _apiClient.SendPostRequest(Url(applicationIdentifier, "login"), request);
            return result.JsonObject["data"] as JObject;
        }

        /// <summary>
        /// List integration login fields. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.integration.fields">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<IList<IntegrationLoginField>> ListIntegrationLoginFields(string applicationIdentifier)
        {
            CrowdinApiResult result = await _apiClient.SendGetRequest(Url(applicationIdentifier, "login-fields"));
            return _jsonParser.ParseArray<IntegrationLoginField>(result.JsonObject["data"]!);
        }

        /// <summary>
        /// Get application integration settings. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.settings.get">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> GetApplicationSettings(string applicationIdentifier, long projectId)
        {
            var @params = new IntegrationSettingsParams { ProjectId = projectId };
            CrowdinApiResult result = await _apiClient.SendGetRequest(Url(applicationIdentifier, "settings"), @params.ToQueryParams());
            return (JObject)result.JsonObject["data"]!;
        }

        /// <summary>
        /// Update application integration settings. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.settings.update">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task UpdateApplicationSettings(string applicationIdentifier, UpdateApplicationSettingsRequest request)
        {
            await _apiClient.SendPostRequest(Url(applicationIdentifier, "settings"), request);
        }

        /// <summary>
        /// Get integration sync settings. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.sync.settings.get">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JToken> GetSyncSettings(string applicationIdentifier, long projectId, string provider)
        {
            var @params = new IntegrationSettingsParams { ProjectId = projectId, Provider = provider };
            CrowdinApiResult result = await _apiClient.SendGetRequest(Url(applicationIdentifier, "sync-settings"), @params.ToQueryParams());
            return result.JsonObject["data"]!;
        }

        /// <summary>
        /// Update integration sync settings. Documentation:
        /// <a href="https://support.crowdin.com/developer/api/v2/#tag/Applications/operation/api.applications.integrations.sync.settings.update">Crowdin API</a>
        /// </summary>
        [PublicAPI]
        public async Task UpdateSyncSettings(string applicationIdentifier, UpdateApplicationSyncSettingsRequest request)
        {
            await _apiClient.SendPostRequest(Url(applicationIdentifier, "sync-settings"), request);
        }
    }
}
