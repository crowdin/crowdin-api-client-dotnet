using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Crowdin.Api.Core;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Crowdin.Api.Applications
{
    public class ApplicationsApiExecutor
    {
        private readonly ICrowdinApiClient _apiClient;
        private readonly IJsonParser _jsonParser;

        public ApplicationsApiExecutor(ICrowdinApiClient apiClient)
        {
            _apiClient = apiClient;
            _jsonParser = apiClient.DefaultJsonParser;
        }

        public ApplicationsApiExecutor(ICrowdinApiClient apiClient, IJsonParser jsonParser)
        {
            _apiClient = apiClient;
            _jsonParser = jsonParser;
        }

        /// <summary>
        /// Get Application Data. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.applications.api.get">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.applications.api.get">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> GetApplicationData(string applicationIdentifier, string path)
        {
            string url = FormUrl_Applications(applicationIdentifier, path);
            CrowdinApiResult result = await _apiClient.SendGetRequest(url);
            return result.JsonObject;
        }

        /// <summary>
        /// Update or Restore Application Data. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.applications.api.put">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.applications.api.put">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> UpdateOrRestoreApplicationData(string applicationIdentifier, string path, object request)
        {
            string url = FormUrl_Applications(applicationIdentifier, path);
            CrowdinApiResult result = await _apiClient.SendPutRequest(url, request);
            return result.JsonObject;
        }

        /// <summary>
        /// Add Application Data. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.applications.api.post">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.applications.api.post">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> AddApplicationData(string applicationIdentifier, string path, object request)
        {
            string url = FormUrl_Applications(applicationIdentifier, path);
            CrowdinApiResult result = await _apiClient.SendPostRequest(url, request);
            return result.JsonObject;
        }

        /// <summary>
        /// Delete Application Data. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.applications.api.delete">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.applications.api.delete">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task DeleteApplicationData(string applicationIdentifier, string path)
        {
            string url = FormUrl_Applications(applicationIdentifier, path);
            HttpStatusCode statusCode =  await _apiClient.SendDeleteRequest(url);
            Utils.ThrowIfStatusNot204(statusCode, $"Application {applicationIdentifier} data removal failed");
        }

        /// <summary>
        /// Edit Application Data. Documentation:
        /// <a href="https://support.crowdin.com/api/v2/#operation/api.applications.api.patch">Crowdin API</a>
        /// <a href="https://support.crowdin.com/enterprise/api/#operation/api.applications.api.patch">Crowdin Enterprise API</a>
        /// </summary>
        [PublicAPI]
        public async Task<JObject> EditApplicationData(string applicationIdentifier, string path, object patches)
        {
            string url = FormUrl_Applications(applicationIdentifier, path);
            CrowdinApiResult result = await _apiClient.SendPatchRequest(url, patches);
            return result.JsonObject;
        }

        private string FormUrl_Applications(string applicationIdentifier, string path)
        {
            return $"/applications/{applicationIdentifier}/api/{path}";
        }
    }
}